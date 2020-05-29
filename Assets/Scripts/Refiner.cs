using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiner : MonoBehaviour
{
    [SerializeField] FloatDataValue resourceData;
    [SerializeField] float refineRatio;
    [SerializeField] float collectingrange;
    [SerializeField] LineRenderer lines;

    float unrefinedResource;
    int amountLines;
    List<ResourceProducer> producers;
    
    // Start is called before the first frame update
    void Start()
    {
        producers = new List<ResourceProducer>();

        UpdateNearbyProducers();
        InvokeRepeating("Refine", 0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        DrawConnection();
    }

    // Get the gatherers inside the collectionRange
    void UpdateNearbyProducers()
    {
        producers.Clear();
        ResourceProducer[] foundProducers;
        foundProducers = FindObjectsOfType<ResourceProducer>();

        for (int i = 0; i < foundProducers.Length; i++)
        {
            if (Vector3.Distance(foundProducers[i].transform.position, transform.position) <= collectingrange)
            {
                //Debug.Log("producer inside the range found!!!!");
                if(foundProducers[i].tag == "Producer")
                {
                    producers.Add(foundProducers[i]);
                }
            }
        }
    }

    //Draw a line to every gatherer inside the collectionRange
    void DrawConnection()
    {
        lines.positionCount = (producers.Count * 2);
        
        for (int i = 0; i < producers.Count; i++)
        {
            lines.SetPosition(2 * i, transform.position);
            lines.SetPosition((2 * i) + 1, producers[i].anchorPos.position);
        }
    }

    //Refine resources gathered gatherers inside the collectionRange
    void Refine()
    {
        UpdateNearbyProducers();
        for (int i = 0; i < producers.Count; i++)
        {
            if (Vector3.Distance(transform.position, producers[i].transform.position) <= collectingrange)
            {
                unrefinedResource += producers[i].GetComponent<ResourceProducer>().EmptyStockPile();
            }
        }
        resourceData.value += unrefinedResource / refineRatio;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,collectingrange);
    }
}
