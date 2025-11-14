using JetBrains.Annotations;
using NUnit.Framework;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AuctionData", menuName = "Scriptable Objects/AuctionData")]
public class AuctionData : ScriptableObject
{
    private FloatVariable m_highestBid;
    //private StorageData m_currentStorage;

    private event Action m_auctionUp;
    private Timer m_bettingTimer;
    private Timer m_countDown;
}
