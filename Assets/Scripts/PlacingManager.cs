using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    [SerializeField] GameObject towerBase;
    [SerializeField] GameObject ActivePlaceableObject;
    private Transform pos;


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "Ground")
                {
                    PlaceBase(hit);
                }
                else if (hit.transform.tag == "Building")
                {
                    hit.transform.GetComponent<BuildablePlace>().PlaceObj(ActivePlaceableObject);
                }
            }

        }
    }

    void PlaceBase(RaycastHit hitInfo)
    {
        GameObject obj = Instantiate(towerBase, hitInfo.point, new Quaternion());
    }

}
