using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BakeryController : MonoBehaviour
{

    GameManager GM;
    public Image squareFillImage;
    public Transform takeReference;
    public Transform bakeReference;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void GetAllSuply()
    {
        foreach (var supply in GM.supplyList)
        {
            supply.transform.parent = takeReference;
            supply.transform.DOMove(takeReference.position, 1f);
            GM.cookingList.Add(supply);
        }
        GM.supplyList.RemoveRange(0, GM.supplyList.Count);
        StartCoroutine(StartCooking());
    }

    private IEnumerator StartCooking()
    {
        int index = 0;
        foreach (var cooking in GM.cookingList)
        {
            yield return new WaitForSeconds(1f);
            cooking.transform.parent = bakeReference;
            cooking.transform.position = new Vector3(bakeReference.position.x, bakeReference.position.y + 0.15f * (bakeReference.childCount - 1), bakeReference.position.z);
            GM.cookedList.Add(cooking);
            index = index + 1;
        }
        GM.cookingList.RemoveRange(0, GM.cookingList.Count);
    }

    public void FillSquareImage(float value)
    {
        squareFillImage.fillAmount += value;
    }

    public void ResetSquareImage()
    {
        squareFillImage.fillAmount = 0;
    }

}
