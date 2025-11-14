using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomSouvenir", menuName = "Scriptable Objects/RandomSouvenir")]
public class RandomSouvenir : ScriptableObject
{
    [SerializeField] public Material m_mesh;
    [SerializeField] public float WorthValue = 1;
    [SerializeField] public Condition conditions;
    public enum Condition
    {
        FactoryNew,
        MinimalUsed,
        Used
    }
}
