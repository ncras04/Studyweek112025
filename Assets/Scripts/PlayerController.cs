using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData m_player;
    [SerializeField] private AuctionData m_auctionData;
    private float m_potentialBid;

    public event Action Fault
    {
        add
        {
            m_fault -= value;
            m_fault += value;
        }
        remove
        {
            m_fault -= value;
        }
    }

    private event Action m_fault;

    private Timer m_preBetTimer;
    [SerializeField] float m_preBetTime;

    void Start()
    {
        m_player.Action.action.performed += OnInput;
        m_player.Action.action.canceled += OnInputCanceled;
    }

    private void Awake()
    {
        m_auctionData.SetActive(true);
        m_preBetTimer = new Timer(m_preBetTime, OnTimerEnd);
        m_player.ResetAuction();
    }

    private void Update()
    {
        m_preBetTimer.Update(Time.deltaTime);
    }

    private void OnInputCanceled(InputAction.CallbackContext context)
    {
        if (m_player.Budget.Value > m_auctionData.HighestBid.Value)
        {
            if (m_player.Budget.Value >= (m_player.CurrentBet.Value + m_player.PreBet.Value + m_auctionData.BetAmount.Value))
            {
                m_player.PreBet.Value += m_auctionData.BetAmount.Value;
                m_potentialBid = m_auctionData.HighestBid.Value + m_player.PreBet.Value;
                m_preBetTimer.SetTimer();
                return;
            }
        }
        
        FaultyBet();
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        return; //TODO!!
    }

    void OnTimerEnd(Timer _)
    {
        if (m_auctionData.AuctionIsActive)
        {
            if (m_potentialBid > m_auctionData.HighestBid.Value)
            {
                m_player.CurrentBet.Value = m_potentialBid;
                m_player.TempBudget.Value = m_player.Budget.Value - m_player.CurrentBet.Value;
                m_auctionData.HighestBid.Value = m_player.CurrentBet.Value;
                m_player.PreBet.SilentReset(0);
                return;
            }

            FaultyBet();
        }
    }

    private void FaultyBet()
    {
        m_fault?.Invoke();
        m_player.PreBet.SilentReset(0);
    }
}
