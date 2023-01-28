using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerFollower : MonoBehaviour
{

    GameManager GM;
    UIManager UI;
    bool canMove;
    float distanceTravelled;
    Transform money;
    Animator playerAnimator;

    public float moveSpeed;
    public float delay;

    private void Awake()
    {
        money = transform.Find("Money");
        playerAnimator = GetComponent<Animator>();
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        UI = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    private void Start()
    {
        StartCoroutine(TriggerStart(delay));
    }

    private IEnumerator TriggerStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            distanceTravelled += moveSpeed * Time.deltaTime;
            transform.position = GM.customerPathCreator.path.GetPointAtDistance(distanceTravelled);
            transform.rotation = GM.customerPathCreator.path.GetRotationAtDistance(distanceTravelled);
            playerAnimator.SetBool("isWalking", moveSpeed > 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CustomerPathMiddle")
        {
            StartCoroutine(TriggerWithPathMiddle());
        }
        if (other.tag == "CustomerPathFinish")
        {
            Destroy(gameObject, 0f);
        }
    }


    private IEnumerator TriggerWithPathMiddle()
    {
        money.transform.DOScale(new Vector3(5, 5, 5), .5f);
        Destroy(GM.inStoreList[GM.inStoreList.Count - 1], 0f);
        GM.inStoreList.RemoveAt(GM.inStoreList.Count - 1);
        GM.selledBreadCount += 1;
        UI.UpdateScore();
        yield return new WaitForSeconds(1f);
        money.transform.DOScale(Vector3.zero, .3f);
    }

}
