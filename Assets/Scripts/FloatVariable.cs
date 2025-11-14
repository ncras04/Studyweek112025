using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/FloatVariable")]
public class FloatVariable : ScriptableObject
{
    private event Action<float> m_valueChanged;

    public event Action<float> ValueChanged
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

    [SerializeField] private float m_value;
    public float Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if(m_value != value)
            {
                m_value = value;
                m_valueChanged?.Invoke(m_value);
            }
        }
    }

    public void SilentReset(float _newValue)
    {
        m_value = _newValue;
    }
}
