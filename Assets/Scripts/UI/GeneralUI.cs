using System;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GeneralUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_highestBid;
    [SerializeField] TextMeshProUGUI m_countDown;

    [SerializeField] AuctionData m_data;
    [SerializeField] AuctionSystem m_system;

    private void Start()
    {
        m_data.HighestBid.ValueChanged += OnHighestBidChanged;
        m_system.CountdownIntervalReached += OnCountdownInterval;

        m_countDown.text = "";
        m_highestBid.text = "HIGHEST BID:\n" + m_data.HighestBid.Value + "$";
    }

    private void OnHighestBidChanged(float _value)
    {
        m_highestBid.text = "HIGHEST BID:\n" + _value + "$";
    }

    private void OnCountdownInterval(float _value)
    {
        m_countDown.text = _value.ToString("0");
    }
}
