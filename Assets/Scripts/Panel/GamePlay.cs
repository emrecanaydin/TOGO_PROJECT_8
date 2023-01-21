using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GamePlay : MonoBehaviour
{

    public float distanceTravelled;

    GameManager GM;
    Animator playerAnimator;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<GameManager>();
        playerAnimator = GM.playerObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            distanceTravelled += GM.playerMoveSpeed * Time.deltaTime;
            GM.playerObject.transform.position = GM.pathCreator.path.GetPointAtDistance(distanceTravelled);
            GM.playerObject.transform.rotation = GM.pathCreator.path.GetRotationAtDistance(distanceTravelled);
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
    }

}
