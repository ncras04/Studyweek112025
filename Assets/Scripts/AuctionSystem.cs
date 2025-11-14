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

    void Start()
    {
        m_bettingTimer = new Timer(m_bettingTime, OnBettingTimerEnd);
        m_countDown = new EventTimer(m_interval, m_countdownTime, OnCountdownTimerEnd, OnCountdownInterval);
    }

    public void StartAuction()
    {
        m_data.SetActive(true);
        m_bettingTimer.SetTimer();
    }       

    private void OnCountdownTimerEnd(Timer timer)
    {
        m_data.SetActive(false);
    }

    private void OnBettingTimerEnd(Timer timer)
    {
        m_countDown.SetTimer();
        m_countdownIntervalReached?.Invoke(m_countDown.CurrentTime);
    }

    private void OnCountdownInterval(float _currentTime)
    {
        m_countdownIntervalReached?.Invoke(m_countDown.CurrentTime);
        Debug.Log("TIME!");
    }

    void Update()
    {
        m_bettingTimer.Update(Time.deltaTime);
        m_countDown.Update(Time.deltaTime);
    }
}
