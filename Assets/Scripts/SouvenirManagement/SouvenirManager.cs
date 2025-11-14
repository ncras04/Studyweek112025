using UnityEngine;

public class SouvenirManager : MonoBehaviour
{
    public SouvenirSingle[] m_Souvenirs;
    [SerializeField] FloatVariable m_value;
    [SerializeField] IntVariable m_count;
    public float WorthValue;

    void Start()
    {
        m_Souvenirs = FindObjectsByType<SouvenirSingle>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);


        for (int i = 0; i < m_Souvenirs.Length; i++)
        {
            WorthValue += m_Souvenirs[i].WorthValue * m_Souvenirs[i].Condition;
        }
        m_value.Value = WorthValue;
        m_count.Value = m_Souvenirs.Length;
    }


}
