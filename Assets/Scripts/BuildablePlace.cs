using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildablePlace : MonoBehaviour
{
    [SerializeField] Transform transformObjPos;
    bool occupied;

    // Start is called before the first frame update
    void Start()
    {
        occupied = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceObj(GameObject objToPlace)
    {
        if (!occupied)
        {
            Instantiate(objToPlace, transformObjPos.position, new Quaternion());
            occupied = true;
            //BuildEffect();
        }
    }
}
