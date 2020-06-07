using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingUI : MonoBehaviour
{
    

    public void ChooseBuilding(string name)
    {
        PlacingManager.Instance.GetBuilding(name);
    }
}
