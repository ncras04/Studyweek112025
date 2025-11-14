using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerData m_player;
    [SerializeField] private AuctionData m_auctionData;

    private Timer m_preBetTimer;
    [SerializeField] float m_preBetTime;

    void Start()
    {
        m_player.Action.action.performed += OnInput;
        m_player.Action.action.canceled += OnInputCanceled;
    }

    private void Awake()
    {
        m_preBetTimer = new Timer(m_preBetTime, OnTimerEnd);
    }

    private void Update()
    {
        m_preBetTimer.Update(Time.deltaTime);
    }

    private void OnInputCanceled(InputAction.CallbackContext context)
    {
        m_preBetTimer.SetTimer();
    }

    private void OnInput(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    void OnTimerEnd(Timer _timer)
    {
        if(m_player.TempBudget.Value > m_auctionData.HighestBid.Value)
        {

        }
    }
}
