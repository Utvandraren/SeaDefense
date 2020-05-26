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
    List<GameObject> producers;
    


    // Start is called before the first frame update
    void Start()
    {
        producers = new List<GameObject>();

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
        GameObject[] foundProducers;
        foundProducers = GameObject.FindGameObjectsWithTag("Producer");
        Debug.Log("array stored " + foundProducers.Length.ToString() + " producers");


        for (int i = 0; i < foundProducers.Length; i++)
        {
            if (Vector3.Distance(foundProducers[i].transform.position, transform.position) <= collectingrange)
            {
                Debug.Log("producer inside the range found!!!!");
                //GameObject obj = foundProducers[i];
                producers.Add(foundProducers[i]);
                
            }
            //producers.Add(foundProducers[i].gameObject);
            Debug.Log("Hello");
        }

        //producers.AddRange(GameObject.FindGameObjectsWithTag("Producer"));
        //Debug.Log(producers.Count.ToString());

    }

    //Draw a line to every gatherer inside the collectionRange
    void DrawConnection()
    {
        lines.positionCount = (producers.Count * 3);

        int iteration = 0;

        for (int i = 0; i < producers.Count; i++)
        {
            lines.SetPosition(0, transform.position);

            lines.SetPosition(i + 1 + iteration, producers[i].transform.position);
            lines.SetPosition(i + 2 + iteration, producers[i].transform.position);

            lines.SetPosition(i + 3 + iteration, transform.position);

            iteration += 3;

        }
    }

    //Refine resources gathered gatherers inside the collectionRange
    void Refine()
    {
        for (int i = 0; i < producers.Count; i++)
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
