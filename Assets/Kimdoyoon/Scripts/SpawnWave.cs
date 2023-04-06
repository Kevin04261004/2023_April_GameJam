using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : MonoBehaviour
{
    [SerializeField]
    private Transform[] point;
    public int Turn =0;
    private void Start()
    {
        GameManager.instance.objectpool.Get(1, point[0]);
        Turn = 0;
    }
    public void TurnEnd()
    {
        for(int i =0; i<point.Length;i++)
        {
            for(int j =0; j < point[i].childCount;j++)
            {
                point[i].GetChild(j).gameObject.GetComponent<Enemy>().MoveDown();
            }
        }
        Turn++;
        switch (Turn) //스테이지 제작 가능.
        {
            case 1:
                GameManager.instance.objectpool.Get(1, point[1]);
                GameManager.instance.objectpool.Get(1, point[2]);
                break;
            case 2:
                GameManager.instance.objectpool.Get(1, point[3]);
                GameManager.instance.objectpool.Get(1, point[5]);
                break;
            case 3:
                GameManager.instance.objectpool.Get(1, point[1]);
                GameManager.instance.objectpool.Get(1, point[2]);
                GameManager.instance.objectpool.Get(1, point[3]);
                GameManager.instance.objectpool.Get(1, point[4]);
                break;
            default:
                break;
        }
    }
}
