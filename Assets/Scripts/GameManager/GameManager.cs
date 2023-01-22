using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation;
using TMPro;

public class GameManager : MonoBehaviour
{


    [Header("Player")]
    public Transform playerReference;
    public float playerMoveSpeed;
    public GameObject playerTopCanvas;
    public TextMeshProUGUI playerTopText;
    public float selledBreadCount;

    [Header("Taking")]
    public Image takingFillImage;

    [Header("Path Creator")]
    public PathCreator pathCreator;

    [Header("Panel")]
    public TextMeshProUGUI profitText;

    [Header("Zone Refecences")]
    public GameObject takingReference;
    public GameObject bakedReference;
    public GameObject storeReference;

    [Header("Prefeabs")]
    public GameObject bread;

    [Header("Collected List")]
    public List<GameObject> collectedList = new List<GameObject>();


}
