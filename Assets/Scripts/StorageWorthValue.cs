using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StorageWorthValue : MonoBehaviour
{
    public SouvenirSingle[] m_Souvenirs;
    public float WorthValue;

    void Start()
    {
        m_Souvenirs = FindObjectsByType<SouvenirSingle>(
            FindObjectsInactive.Include, FindObjectsSortMode.None);
        

        for (int i = 0; i < m_Souvenirs.Length; i++)
        {
            WorthValue += m_Souvenirs[i].WorthValue;
        }
    }



    
}
