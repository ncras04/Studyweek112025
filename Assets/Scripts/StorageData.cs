using UnityEngine;

[CreateAssetMenu(fileName = "StorageData", menuName = "Scriptable Objects/StorageData")]
public class StorageData : ScriptableObject
{
    public FloatVariable StorageValue { get; private set; }
    public IntVariable SouvenirCount { get; private set; }

    [SerializeField] private FloatVariable m_storageValue;
    [SerializeField] private IntVariable m_souvenirCount;

    public void SetStorageValue(float _value)
    {
        StorageValue.Value = _value;
    }
}
