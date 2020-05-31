using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    //[SerializeField]Transform target;
    float countDown = 5f;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        //target = WaveManager.Instance.enemyTarget;
        agent = transform.GetComponent<NavMeshAgent>();
        agent.destination = WaveManager.Instance.enemyTarget.position;
        currentTime = countDown;
    }

    
}
