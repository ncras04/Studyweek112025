using UnityEngine;
using Random = UnityEngine.Random;

public class SouvenirManager : MonoBehaviour
{
    public SouvenirSingle[] m_Souvenirs;
    [SerializeField] FloatVariable m_value;
    [SerializeField] IntVariable m_count;
    private float WorthValue;


    void Awake()
    {
        RandomItems();
        Invoke("ValueSum", 2);
    }

    private void FillArray()
    {
        m_Souvenirs = FindObjectsByType<SouvenirSingle>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);
    }

    private void RandomItems()
    {
        FillArray();
        int emptyRan = Random.Range(0, 2);
        int minRan = Random.Range(emptyRan, m_Souvenirs.Length / 2);
        int maxRan = Random.Range(m_Souvenirs.Length / 2, m_Souvenirs.Length);

        for (int i = minRan; i < maxRan; i++)
        {
            Destroy(m_Souvenirs[i].gameObject);
        }
    }

    private void ValueSum()
    {
        FillArray();
        for (int i = 0; i < m_Souvenirs.Length; i++)
        {
            WorthValue += m_Souvenirs[i].WorthValue;
        }
        m_value.Value = WorthValue;
        m_count.Value = m_Souvenirs.Length;
    }
}
