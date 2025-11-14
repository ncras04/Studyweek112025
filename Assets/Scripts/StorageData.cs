using UnityEngine;

[CreateAssetMenu(fileName = "StorageData", menuName = "Scriptable Objects/StorageData")]
public class StorageData : ScriptableObject
{
    public FloatVariable StorageValue { get => m_storageValue; private set => m_storageValue = value; }
    public IntVariable SouvenirCount { get => m_souvenirCount; private set => m_souvenirCount = value; }

    [SerializeField] private FloatVariable m_storageValue;
    [SerializeField] private IntVariable m_souvenirCount;

    public void SetStorageValue(float _value)
    {
        StorageValue.Value = _value;
    }
}
