using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new DataValue", menuName = "Values/float data")]
public class FloatDataValue : ScriptableObject
{
    [HideInInspector]
    public float value;
    [HideInInspector]
    public float resourcePoduction;

    [SerializeField] float _startValue;
    [SerializeField] float _startResourceProduction;

    public void ResetData()
    {
        value = _startValue;
    }
}
