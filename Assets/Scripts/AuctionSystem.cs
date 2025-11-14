using System;
using System.Collections.Generic;
using UnityEngine;

public class AuctionSystem : MonoBehaviour
{
    private Timer m_bettingTimer;
    private EventTimer m_countDown;

    [SerializeField] private float m_bettingTime;
    [SerializeField] private float m_countdownTime;
    [SerializeField] private float m_interval;
    [SerializeField] private AuctionData m_data;
    [SerializeField] private List<PlayerData> m_players;

    public event Action<float> CountdownIntervalReached
    {
        add
        {
            m_countdownIntervalReached -= value;
            m_countdownIntervalReached += value;
        }
        remove
        {
            m_countdownIntervalReached -= value;
        }
    }
    private event Action<float> m_countdownIntervalReached;

    private void Awake()
    {
        InitAuction();
    }

    public void InitAuction()
    {
        m_bettingTimer = new Timer(m_bettingTime, OnBettingTimerEnd);
        m_countDown = new EventTimer(m_interval, m_countdownTime, OnCountdownTimerEnd, OnCountdownInterval);

        m_data.HighestBid.SilentReset(CalculateStartingBid());
        m_data.SetActive(true);
        m_bettingTimer.SetTimer();
    }

    private float CalculateStartingBid()
    {
        return 500; //TODO Calculate Starting Bid
    }      

    private void OnCountdownTimerEnd(Timer timer)
    {
        m_data.SetActive(false);

        foreach (PlayerData player in m_players)
        {
            if(m_data.HighestBid.Value == player.CurrentBet.Value)
            {
                player.Wins.Value += m_data.CurrentStorage.StorageValue.Value;
                player.Budget.Value = player.TempBudget.Value;
            }

            player.ResetAuction();
        }
    }
    private void OnBettingTimerEnd(Timer timer)
    {
        m_countDown.SetTimer();
        m_countdownIntervalReached?.Invoke(m_countDown.CurrentTime);
    }

    private void OnCountdownInterval(float _currentTime)
    {
        m_countdownIntervalReached?.Invoke(m_countDown.CurrentTime);
    }

    void Update()
    {
        m_bettingTimer.Update(Time.deltaTime);
        m_countDown.Update(Time.deltaTime);
    }
}
