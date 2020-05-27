using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new DataValue", menuName = "Values/int data")]
public class IntDataValue : ScriptableObject
{
    [HideInInspector]
    public int value;
    
    [SerializeField] int _startValue;

    public void ResetData()
    {
        value = _startValue;
    }
}
