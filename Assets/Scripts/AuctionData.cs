using JetBrains.Annotations;
using NUnit.Framework;
using System;
using System.Data.SqlTypes;
using UnityEngine;

[CreateAssetMenu(fileName = "AuctionData", menuName = "Scriptable Objects/AuctionData")]
public class AuctionData : ScriptableObject
{
    public event Action<bool> AuctionIsActiveChanged
    {
        add
        {
            m_auctionIsActiveChanged -= value;
            m_auctionIsActiveChanged += value;
        }
        remove
        {
            m_auctionIsActiveChanged -= value;
        }
    }

    public FloatVariable HighestBid { get => m_highestBid; private set => m_highestBid = value; }
    public StorageData CurrentStorage { get => m_currentStorage; private set => m_currentStorage = value; }

    [SerializeField] private FloatVariable m_highestBid;
    [SerializeField] private StorageData m_currentStorage;
    public FloatVariable BetAmount { get => m_betAmount; private set => m_betAmount = value; }

    [SerializeField] private FloatVariable m_betAmount;

    private bool m_auctionIsActive = true;

    public bool AuctionIsActive
    {
        get
        {
            return m_auctionIsActive;
        }
        set
        {
            if (m_auctionIsActive != value)
            {
                m_auctionIsActive = value;
                m_auctionIsActiveChanged?.Invoke(m_auctionIsActive);
            }
        }
    }

    private event Action<bool> m_auctionIsActiveChanged;

    public void SetNextStorage(StorageData _newStorage)
    {
        CurrentStorage = _newStorage;
    }

    public void SetActive(bool _isActive)
    {
        AuctionIsActive = _isActive;
    }
}
