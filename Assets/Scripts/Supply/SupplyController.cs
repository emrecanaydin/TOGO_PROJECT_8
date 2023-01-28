using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupplyController : MonoBehaviour
{
    public Image squareFillImage;
    public GameObject supplyObject;

    public GameObject GenerateSupply()
    {
        GameObject generatedSupply = Instantiate(supplyObject, transform.position, Quaternion.identity);
        return generatedSupply;
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
