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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_bettingTimer = new Timer(m_bettingTime, OnBettingTimerEnd);
        m_countDown = new EventTimer(m_interval, m_countdownTime, OnCountdownTimerEnd, OnCountdownInterval);
    }

    private void OnCountdownTimerEnd(Timer timer)
    {
        m_data.SetActive(false);
    }

    private void OnBettingTimerEnd(Timer timer)
    {
        m_countDown.SetTimer();
    }

    private void OnCountdownInterval(float _currentTime)
    {
        Debug.Log("TIME!");
    }

    void Update()
    {
        m_bettingTimer.Update(Time.deltaTime);
        m_countDown.Update(Time.deltaTime);
    }
}
