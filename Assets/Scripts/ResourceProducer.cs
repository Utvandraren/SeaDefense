using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceProducer : MonoBehaviour
{
    [SerializeField] float startResourceProduction;
    float resourceProduction;

    [HideInInspector]
    public float resourceStockpile;

    // Start is called before the first frame update
    void Start()
    {
        resourceProduction = startResourceProduction;
        InvokeRepeating("Produce", 0f, 1f);
    }

    void Produce()
    {
        resourceStockpile += resourceProduction;
        //Show NumbersEffectAbovebuilding
        
        //Debug.LogFormat(transform.name + "  " + "Prod: " + resourceProduction.ToString() + "  " + "stockpile" + resourceStockpile.ToString());
    }

    void activateLettertEffect()
    {

    }

    public float EmptyStockPile()
    {
        float amount = resourceStockpile;
        resourceStockpile = 0;
        return amount;
    }
}
