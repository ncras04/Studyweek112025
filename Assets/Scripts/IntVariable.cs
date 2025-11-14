using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IntVariable", menuName = "Scriptable Objects/IntVariable")]
public class IntVariable : ScriptableObject
{
    private event Action<int> m_valueChanged;

    public event Action<int> ValueChanged
    {
        add
        {
            m_valueChanged -= value;
            m_valueChanged += value;

        }
        remove
        {
            m_valueChanged -= value;
        }
    }

    private int m_value;
    public int Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if (m_value != value)
            {
                m_value = value;
                m_valueChanged?.Invoke(m_value);
            }
        }
    }

    public void SilentReset(int _newValue)
    {
        m_value = _newValue;
    }
}
