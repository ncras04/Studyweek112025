using System;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] PlayerData m_player;
    [SerializeField] TextMeshProUGUI m_budgetText;
    [SerializeField] char m_currency = '$';

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_player.Budget.ValueChanged += OnBudgetChanged;
        InitializeUI();
    }

    private void InitializeUI()
    {
        m_budgetText.text = m_player.Budget.Value.ToString() + m_currency;
    }

    private void OnBudgetChanged(float _newBudget)
    {
        m_budgetText.text = _newBudget.ToString() + m_currency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceBudget() 
    {
        
    
    }
}
