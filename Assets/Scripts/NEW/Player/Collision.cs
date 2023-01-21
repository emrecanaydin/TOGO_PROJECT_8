using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    GameManager GM;
    bool canStackHamur;
    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollectCircle")
        {
            Debug.Log(other.tag);
            canStackHamur = true;
            StartCoroutine(GetBread());
            //GM.playerTopCanvas.SetActive(true);
        }
        if (other.tag == "TakeCircle")
        {
            //StartCoroutine(StartTake());
            //GM.playerTopCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HamurCircle")
        {
            canStackHamur = false;
            //GM.playerTopCanvas.SetActive(false);
        }
        if (other.tag == "TakeCircle")
        {
            //GM.playerTopCanvas.SetActive(false);
        }


    }

    //private IEnumerator StartTake()
    //{
    //    yield return new WaitForSeconds(1f);
    //    foreach (var collected in GM.collectedList)
    //    {
    //        collected.transform.DOMove(GM.firin.transform.position, 1f);
    //    }
    //}

    private IEnumerator GetBread()
    {
        yield return new WaitForSeconds(1f);
        GameObject clonedBread = Instantiate(GM.bread, transform.position, Quaternion.Euler(new Vector3(-90, 0, 50)));
        Transform collectPoint = transform.Find("CollectPoint");
        clonedBread.transform.parent = collectPoint;
        clonedBread.transform.position = new Vector3(collectPoint.transform.position.x, collectPoint.transform.position.y + GM.collectedList.Count, collectPoint.transform.position.z);
        GM.collectedList.Add(clonedBread);
        if (GM.collectedList.Count == 5)
        {
            //GM.playerTopCount.text = $"MAX \n {GM.collectedList.Count} / 5";
        }
        else
        {
            //GM.playerTopCount.text = $"{GM.collectedList.Count} / 5";
        }
        if (canStackHamur && GM.collectedList.Count < 5)
        {
            StartCoroutine(GetBread());
        }
    }
}
