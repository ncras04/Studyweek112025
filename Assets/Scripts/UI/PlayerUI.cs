using System;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] PlayerData m_player;
    [SerializeField] AuctionData m_data;
    [SerializeField] TextMeshProUGUI m_budgetText;
    [SerializeField] TextMeshProUGUI m_preBetText;
    [SerializeField] Animator m_preBetAnimator;
    [SerializeField] TextMeshProUGUI m_currentBetText;
    [SerializeField] char m_currency = '$';

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_player.TempBudget.ValueChanged += OnBudgetChanged;
        m_player.PreBet.ValueChanged += OnPreBetChanged;
        m_player.CurrentBet.ValueChanged += OnCurrentBetChanged;

        InitializeUI();
    }

    private void OnCurrentBetChanged(float _newValue)
    {
        m_currentBetText.text = "Your Bid:\n" + m_player.CurrentBet.Value.ToString() + m_currency;
    }
    private void OnPreBetChanged(float _newValue)
    {
        m_preBetText.text = "-" + m_player.PreBet.Value.ToString() + m_currency;
        m_preBetAnimator.SetTrigger("TriggerAnim");
    }
    private void InitializeUI()
    {
        m_budgetText.text = m_player.TempBudget.Value.ToString() + m_currency;
        m_preBetText.text = "0" + m_currency;
        m_currentBetText.text = "Your Bid:\n";
    }

    public void OnBudgetChanged(float _newBudget)
    {
        m_budgetText.text = _newBudget.ToString() + m_currency;
    }
}
