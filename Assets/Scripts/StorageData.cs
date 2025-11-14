using UnityEngine;

[CreateAssetMenu(fileName = "StorageData", menuName = "Scriptable Objects/StorageData")]
public class StorageData : ScriptableObject
{
    public FloatVariable StorageValue { get; private set; }

    [SerializeField] private FloatVariable m_storageValue;
    //[SerializeField] private PlayerData m_winningPlayer;

    public void SetStorageValue(float _value)
    {
        StorageValue.Value = _value;
    }
}
