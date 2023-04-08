using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
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
    public int GetTurn()
    {
        return Turn;
    }
    public void TurnEnd() // 턴 오버 : 여기서 턴 엔드 이벤트 진행 << 추가할것들 여기서.
    {
        GameManager.instance.UImanager.SetStage();
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
                GameManager.instance.objectpool.Get(3, point[2]);
                break;
            case 2:
                GameManager.instance.objectpool.Get(3, point[3]);
                GameManager.instance.objectpool.Get(1, point[5]);
                break;
            case 3:
                GameManager.instance.objectpool.Get(1, point[1]);
                GameManager.instance.objectpool.Get(3, point[2]);
                GameManager.instance.objectpool.Get(2, point[3]);
                GameManager.instance.objectpool.Get(1, point[4]);
                break;
            default:
                break;
        }
    }
}
