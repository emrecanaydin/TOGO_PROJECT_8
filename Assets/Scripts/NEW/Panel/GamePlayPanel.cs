using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPanel : MonoBehaviour
{
    GameManager GM;
    float distanceTravelled;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            distanceTravelled += GM.playerMoveSpeed * Time.deltaTime;
            GM.playerReference.transform.position = GM.pathCreator.path.GetPointAtDistance(distanceTravelled);
            GM.playerReference.transform.rotation = GM.pathCreator.path.GetRotationAtDistance(distanceTravelled);
        }
        GM.playerReference.GetComponent<Animator>().SetBool("isWalking", Input.GetMouseButton(0));
    }

}
