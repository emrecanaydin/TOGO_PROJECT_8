using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    GameManager GM;

    public TextMeshProUGUI profitText;

    [Header("Player Top Text")]
    public GameObject playerTopCanvas;
    public TextMeshProUGUI playerTopText;

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void UpdateScore()
    {
        float score = GM.selledBreadCount * 5;
        profitText.text = score.ToString();
    }

    public void ShowPlayerTopText()
    {
        playerTopCanvas.SetActive(true);
    }

    public void HidePlayerTopText()
    {
        playerTopCanvas.SetActive(false);
    }

    public void UpdatePlayerTopText()
    {
        string countText = GM.supplyList.Count == 5 ? "MAX \n" : "";
        countText += $"{GM.supplyList.Count} / 5";
        playerTopText.text = countText;
    }

}