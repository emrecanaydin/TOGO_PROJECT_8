using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StoreController : MonoBehaviour
{

    GameManager GM;
    UIManager UI;
    public Transform instantiatePoint;
    public GameObject customerPrefab;
    public List<Transform> collectPointList = new List<Transform>();
    public List<Material> customerMaterialList = new List<Material>();

    private void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        UI = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        CheckBreadAndGenerateCustomer();
    }

    private void CheckBreadAndGenerateCustomer()
    {
        if (GM.inStoreList.Count > 0)
        {
            if(GameObject.FindGameObjectsWithTag("Customer").Length <= GM.inStoreList.Count - 1)
            {
                GameObject customer = Instantiate(customerPrefab, new Vector3(21f, 2.98f, -3.4f), Quaternion.identity);
                customer.transform.parent = transform.Find("CustomerArea").transform;
                customer.transform.position = instantiatePoint.position;
                customer.transform.Find("Stick").GetComponent<Renderer>().material = customerMaterialList[Random.Range(0, customerMaterialList.Count)];
                customer.GetComponent<CustomerFollower>().delay = GameObject.FindGameObjectsWithTag("Customer").Length;
            }
        }
    }

    public void GetAllBaked()
    {
        int index = 0;
        foreach (var taked in GM.takedList)
        {
            Transform collectPoint = collectPointList[index];
            taked.transform.parent = collectPoint;
            taked.transform.DOMove(new Vector3(collectPoint.position.x, collectPoint.position.y, collectPoint.position.z), 0.5f);
            taked.transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, -90, transform.localRotation.z));
            taked.transform.localScale = taked.transform.localScale * 1.5f;
            GM.inStoreList.Add(taked);
            index = index + 1;
        }
        GM.takedList.RemoveRange(0, GM.takedList.Count);
        UI.UpdatePlayerTopText();
    }
}
