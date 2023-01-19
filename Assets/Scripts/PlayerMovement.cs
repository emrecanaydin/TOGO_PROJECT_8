using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PlayerMovement : MonoBehaviour
{
    public PathCreator pathCreator;
    public float moveSpeed = 5;
    float distanceTravelled;

    private void Update()
    {
        distanceTravelled += moveSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }

}
