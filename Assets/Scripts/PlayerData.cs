using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public string PlayerName { get => m_playerName; private set => m_playerName = value; }
    public InputActionReference Action { get => m_action; private set => m_action = value; }

    public FloatVariable Budget { get => m_budget; private set => m_budget = value; }
    public FloatVariable TempBudget { get => m_tempBudget; private set => m_tempBudget = value; }
    public FloatVariable PreBet { get => m_preBet; private set => m_preBet = value; }
    public FloatVariable CurrentBet { get => m_currentBet; private set => m_currentBet = value; }

    public FloatVariable Wins { get => m_wins; private set => m_wins = value; }

    [SerializeField] private string m_playerName;
    [SerializeField] private InputActionReference m_action;

    [SerializeField] private FloatVariable m_budget;
    [SerializeField] private FloatVariable m_tempBudget;
    [SerializeField] private FloatVariable m_preBet;
    [SerializeField] private FloatVariable m_currentBet;

    [SerializeField] private FloatVariable m_wins;

    [SerializeField] private AuctionData m_auctionData;

    public void SetPlayerName(string _newName) => PlayerName = _newName;
    public bool CheckWin()
    {
        return true;
    }
}
