using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildablePlace : MonoBehaviour
{
    [SerializeField] Transform transformObjPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceObj(GameObject objToPlace)
    {
        Instantiate(objToPlace, transformObjPos.position, new Quaternion());
        //BuildEffect();
    }
}
