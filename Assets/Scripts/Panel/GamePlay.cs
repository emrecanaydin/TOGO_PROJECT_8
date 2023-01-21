using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GamePlay : MonoBehaviour
{
    public PathCreator pathCreator;
    public Transform player;
    public float moveSpeed = 5;
    float distanceTravelled;

    Animator playerAnimator;

    private void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            distanceTravelled += moveSpeed * Time.deltaTime;
            player.transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            player.transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
            playerAnimator.SetBool("isWalking", true);
        } else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

}
