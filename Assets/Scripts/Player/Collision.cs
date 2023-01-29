using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collision : MonoBehaviour
{
    GameManager GM;
    SupplyController supplyController;
    BakeryController bakeryController;
    StoreController storeController;
    UIManager UI;
    Transform trey;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        UI = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        supplyController = GameObject.FindGameObjectWithTag("SupplyController").GetComponent<SupplyController>();
        bakeryController = GameObject.FindGameObjectWithTag("BakeryController").GetComponent<BakeryController>();
        storeController = GameObject.FindGameObjectWithTag("StoreController").GetComponent<StoreController>();
        trey = transform.Find("CollectPoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "StoreCircle":
                TriggerWithStore();
                break;
            default:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "SupplyCircle":
                TriggerWithSupply();
                break;
            case "TakeCircle":
                TriggerWithTake();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "SupplyCircle":
                TriggerExitWithSupply();
                break;
            case "TakeCircle":
                TriggerExitWithTake();
                break;
            case "BakeCircle":
                TriggerExitWithBake();
                break;
            default:
                break;
        }
    }

    private void TriggerWithSupply()
    {
        UI.ShowPlayerTopText();
        if(GM.supplyList.Count < 5 && GM.takedList.Count == 0)
        {
            if (supplyController.squareFillImage.fillAmount < 1)
            {
                supplyController.FillSquareImage(1f * Time.deltaTime);
            }
            else
            {
                supplyController.ResetSquareImage();
                GameObject supply = supplyController.GenerateSupply();
                supply.transform.parent = trey;
                supply.transform.DOMove(new Vector3(trey.transform.position.x, (trey.transform.position.y + .30f * GM.supplyList.Count), trey.transform.position.z), .1f);
                supply.transform.localRotation = Quaternion.Euler(0, 0, 0);
                GM.supplyList.Add(supply);
                UI.UpdatePlayerTopText();
            }
        }
    }

    private void TriggerExitWithSupply()
    {
        UI.HidePlayerTopText();
        supplyController.ResetSquareImage();
    }


    private void TriggerWithTake()
    {
        UI.ShowPlayerTopText();
        if(GM.supplyList.Count > 0)
        {
            if (bakeryController.squareFillImage.fillAmount < 1)
            {
                bakeryController.FillSquareImage(1f * Time.deltaTime);
            }
            else
            {
                bakeryController.ResetSquareImage();
                bakeryController.GetAllSuply();
            }
        } else
        {
            bakeryController.ResetSquareImage();
        }
    }

    private void TriggerExitWithTake()
    {
        UI.HidePlayerTopText();
        bakeryController.ResetSquareImage();
    }


    private void TriggerExitWithBake()
    {
        if (GM.cookedList.Count > 0)
        {
            for (int index = GM.cookedList.Count - 1; index >= 0; index--)
            {
                if (GM.takedList.Count < 5)
                {
                    GameObject cooked = GM.cookedList[index];
                    cooked.transform.parent = trey;
                    cooked.transform.DOMove(new Vector3(trey.transform.position.x, trey.transform.position.y + 0.15f * GM.takedList.Count, trey.transform.position.z), 0.015f);
                    GM.takedList.Add(cooked);
                }
            }
            GM.cookedList.RemoveRange(GM.cookedList.Count - GM.takedList.Count, GM.takedList.Count);
        }
    }


    private void TriggerWithStore()
    {
        storeController.GetAllBaked();
    }

}
