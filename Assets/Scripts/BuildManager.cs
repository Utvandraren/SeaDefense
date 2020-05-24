using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] FloatDataValue _resourceData;
    float currentResource;
    
    

    // Start is called before the first frame update
    void Start()
    {
        currentResource = _resourceData.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
