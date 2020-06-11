using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    Vector3 offSetPosition;
    float offSetDistance;
    float offSetDistanceY;

    // Start is called before the first frame update
    void Start()
    {
        offSetPosition = transform.position;
        offSetDistance = Vector3.Distance(targetTransform.position, transform.position);
        offSetDistanceY = transform.position.y - targetTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
    }

    void UpdatePos()
    {
        offSetPosition = targetTransform.position;
        offSetPosition.y += offSetDistanceY;
        offSetPosition.x -= offSetDistance;
        transform.position = offSetPosition;

    }
}
