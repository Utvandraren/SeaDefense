using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiner : MonoBehaviour
{
    [SerializeField] FloatDataValue resourceData;
    [SerializeField] float refineRatio;
    [SerializeField] float collectingrange;
    float unrefinedResource;
    GameObject[] producers;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Refine", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateNearbyProducers()
    {
        producers = GameObject.FindGameObjectsWithTag("Producer");     
    }

    void Refine()
    {
        UpdateNearbyProducers();

        for (int i = 0; i < producers.Length; i++)
        {
            if (Vector3.Distance(transform.position, producers[i].transform.position) <= collectingrange)
            {
                unrefinedResource += producers[i].GetComponent<ResourceProducer>().EmptyStockPile();
            }
        }

        resourceData.value += unrefinedResource / refineRatio;
        Debug.Log("refine: " + resourceData.value.ToString());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,collectingrange);
    }
}
