using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("About Player")]
    public Transform playerObject;
    public float playerMoveSpeed;
    public TextMeshProUGUI playerTopCount;
    public GameObject playerTopCanvas;

    [Header("Path Creator")]
    public PathCreator pathCreator;

    [Header("Prefabs")]
    public GameObject breadPrefab;

    [Header("References")]
    public GameObject firin;

    [Header("Collected")]
    public List<GameObject> collectedList = new List<GameObject>();

}
