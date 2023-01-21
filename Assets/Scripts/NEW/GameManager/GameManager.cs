using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GameManager : MonoBehaviour
{


    [Header("Player")]
    public Transform playerReference;
    public float playerMoveSpeed;

    [Header("Path Creator")]
    public PathCreator pathCreator;

    [Header("Zone Refecences")]
    public GameObject bakeryReference;
    public GameObject takingReference;
    public GameObject storeReference;

    [Header("Prefeabs")]
    public GameObject bread;

    [Header("Collected List")]
    public List<GameObject> collectedList = new List<GameObject>();


}
