using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public string PlayerName { get; private set; }
    public InputActionReference Action { get; private set; }

    public FloatVariable Budget { get; private set; }
    public FloatVariable TempBudget { get; private set; }
    public FloatVariable PreBet { get; private set; }
    public FloatVariable CurrentBet { get; private set; }

    public FloatVariable Wins { get; private set; }

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
