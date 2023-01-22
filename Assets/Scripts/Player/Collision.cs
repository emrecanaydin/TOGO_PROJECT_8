using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collision : MonoBehaviour
{
    GameManager GM;
    bool canCollect;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CollectCircle")
        {
            canCollect = true;
            StartCoroutine(StartCollect());
            GM.playerTopCanvas.SetActive(true);
        }
        if (other.tag == "TakeCircle")
        {
            StartCoroutine(StartTake());
            GM.playerTopCanvas.SetActive(true);
        }
        if(other.tag == "BakeCircle")
        {
            StartCoroutine(StartBaking());
            GM.playerTopCanvas.SetActive(true);
        }
        if (other.tag == "StoreCircle")
        {
            StartCoroutine(StartSelling());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "CollectCircle")
        {
            GM.takingFillImage.fillAmount += 1f * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CollectCircle")
        {
            canCollect = false;
            GM.playerTopCanvas.SetActive(false);
        }
        if (other.tag == "TakeCircle")
        {
            GM.playerTopCanvas.SetActive(false);
        }
        if (other.tag == "BakeCircle")
        {
            GM.playerTopCanvas.SetActive(false);
        }
    }

    private IEnumerator StartCollect()
    {

        yield return new WaitForSeconds(1f);
        GameObject clonedBread = Instantiate(GM.bread, transform.position, Quaternion.identity);
        Transform collectPoint = transform.Find("CollectPoint");
        clonedBread.transform.parent = collectPoint;
        clonedBread.transform.position = new Vector3(collectPoint.transform.position.x, collectPoint.transform.position.y + GM.collectedList.Count, collectPoint.transform.position.z);
        clonedBread.transform.localRotation = Quaternion.Euler(new Vector3(-90, 0, 50));
        GM.collectedList.Add(clonedBread);
        string countText = GM.collectedList.Count == 5 ? "MAX \n" : "";
        countText += $"{GM.collectedList.Count} / 5";
        GM.playerTopText.text = countText;
        if (canCollect && GM.collectedList.Count < 5)
        {
            StartCoroutine(StartCollect());
        }
    }

    private IEnumerator StartTake()
    {
        yield return new WaitForSeconds(1f);
        foreach (var collected in GM.collectedList)
        {
            collected.transform.parent = GM.takingReference.transform;
            collected.transform.DOMove(GM.takingReference.transform.position, 1f);
        }
        StartCoroutine(StartCooking());
    }

    private IEnumerator StartCooking()
    {
        int index = 0;
        foreach (var collected in GM.collectedList)
        {
            yield return new WaitForSeconds(1f);
            Vector3 position = new Vector3(GM.bakedReference.transform.position.x, GM.bakedReference.transform.position.y + index, GM.bakedReference.transform.position.z);
            collected.transform.position = position;
            collected.transform.parent = GM.bakedReference.transform;
            index = index + 1;
        }
    }

    private IEnumerator StartBaking()
    {
        yield return new WaitForSeconds(1f);
        int index = 0;
        foreach (var collected in GM.collectedList)
        {
            Transform collectPoint = transform.Find("CollectPoint");
            collected.transform.parent = collectPoint;
            Vector3 position = new Vector3(collectPoint.transform.position.x, collectPoint.transform.position.y + index, collectPoint.transform.position.z);
            collected.transform.DOMove(position, 1f);
            index = index + 1;
        }
    }

    private IEnumerator StartSelling()
    {
        yield return new WaitForSeconds(1f);
        int index = 0;
        foreach (var collected in GM.collectedList)
        {
            collected.transform.parent = GM.storeReference.transform;
            Vector3 position = new Vector3(GM.storeReference.transform.position.x, GM.storeReference.transform.position.y, GM.storeReference.transform.position.z + index);
            collected.transform.localRotation = Quaternion.Euler(0, 0, 0);
            collected.transform.DOMove(position, 1f);
            index = index + 1;
        }
        GM.selledBreadCount += GM.collectedList.Count;
        float profit = GM.selledBreadCount * 5;
        GM.profitText.text = profit.ToString();
        GM.playerTopText.text = "";
        GM.collectedList.RemoveRange(0, GM.collectedList.Count);
    }

}
