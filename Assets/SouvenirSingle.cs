using System.Diagnostics;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SouvenirSingle : MonoBehaviour
{
    [SerializeField] float Condition;
    [SerializeField] public float WorthValue;

    private void Start()
    {
        EndWorthValue();
    }

    public void EndWorthValue()
    {
        WorthValue *= Condition;

    }
}
