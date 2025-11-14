using UnityEngine;
using static RandomSouvenir;
using Random = UnityEngine.Random;

public class SouvenirSingle : MonoBehaviour
{
    private MeshRenderer m_mesh;
    [SerializeField] public float WorthValue { get; private set; }
    [SerializeField] public float ConditionValue { get; private set; }

    [SerializeField] RandomSouvenir[] m_randomSouvenir;

    private void Start()
    {
        int _random = Random.Range(0, m_randomSouvenir.Length);
        m_mesh = GetComponent<MeshRenderer>();
        ConditionValues(m_randomSouvenir[_random].conditions);
        WorthValue = m_randomSouvenir[_random].WorthValue * ConditionValue;
        m_mesh.material = m_randomSouvenir[_random].m_mesh;
    }

    public void ConditionValues(Condition _conditionValue)
    {
        switch (_conditionValue)
        {
            case Condition.FactoryNew:
                ConditionValue = 1;
                break;
            case Condition.MinimalUsed:
                ConditionValue = 0.75f;
                break;
            case Condition.Used:
                ConditionValue = 0.5f;
                break;
        }
    }
}