using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingManager : MonoBehaviour
{
    BuildingObj ActivePlaceableObject;
    [SerializeField] FloatDataValue resourceData;
    [SerializeField] BuildingObj[] buildings;

   
    // Update is called once per frame
    void Update()
    {
        HandleMouseClick();
    }

    void HandleMouseClick()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.tag == "Ground")
                {
                    GetBuilding("Tower");
                    BuildBuilding(hit);
                }
                else if (hit.transform.tag == "Building")
                {
                    GetBuilding("Artillery");
                    BuildDefense(hit);
                }
            }

        }
    }

    void GetBuilding(string name)
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            if(name == buildings[i].name)
            {
                ActivePlaceableObject = buildings[i];
            }
        }

        
    }

    void BuildDefense(RaycastHit hitInfo)
    {
        if (ActivePlaceableObject.resourceCost >= resourceData.value)
        {
            Debug.Log("Not enough resources");
            return;
        }

        resourceData.value -= ActivePlaceableObject.resourceCost;
        hitInfo.transform.GetComponent<BuildablePlace>().PlaceObj(ActivePlaceableObject.building);
    }


    //Build building if eyou have enough resoruces
    void BuildBuilding(RaycastHit hitInfo)
    {
        if(ActivePlaceableObject.resourceCost >= resourceData.value)
        {
            Debug.Log("Not enough resources");
            return;
        }

        resourceData.value -= ActivePlaceableObject.resourceCost;
        Instantiate(ActivePlaceableObject.building, hitInfo.point, new Quaternion());

    }

}
