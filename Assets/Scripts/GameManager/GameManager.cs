using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("Path Creator")]
    public PathCreator pathCreator;
    public PathCreator customerPathCreator;

    [Header("List")]
    public List<GameObject> supplyList = new List<GameObject>();
    public List<GameObject> cookingList = new List<GameObject>();
    public List<GameObject> cookedList = new List<GameObject>();
    public List<GameObject> takedList = new List<GameObject>();
    public List<GameObject> inStoreList = new List<GameObject>();

}