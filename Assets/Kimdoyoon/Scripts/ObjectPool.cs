using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefabs; // 인스펙터에서 초기화
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
            pools[index] = new List<GameObject>();
    }

    public GameObject Get(int index,Transform parent)
    {
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }
        select.transform.parent = parent.transform;
        select.transform.position = parent.transform.position;
        if (index == 0) // 공을 추가 할때 << 여기다가 추가.
        {
            select.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GameManager.instance.UImanager.SetBallHowMuch();
        }
        return select;
    }

    public void Clear(int index)
    {
        foreach (GameObject item in pools[index])
            item.SetActive(false);
    }

    public void ClearAll()
    {
        for (int index = 0; index < pools.Length; index++)
            foreach (GameObject item in pools[index])
                item.SetActive(false);
    }


}
