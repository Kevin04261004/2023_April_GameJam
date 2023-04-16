using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

[System.Serializable]
public class AllData
{
    public StageData[] Stage;
}
[System.Serializable]
public class StageData
{
    public int Point0;
    public int Point1;
    public int Point2;
    public int Point3;
    public int Point4;
    public int Point5;
    public int StageID;
}
public class SpawnWave : MonoBehaviour
{
    [SerializeField]
    private Transform[] point;
    public int Turn = 0;
    public TextAsset data;
    public AllData datas;
    public int MaxTurn;
    public int[] SpawnEnemy;
    private void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(data.text); // json 읽어들이기
    }
    private void Start()
    {
        GameManager.instance.objectpool.Get(1, point[0]);
        SpawnEnemy = new int[6];
        Turn = 0;
        MaxTurn = datas.Stage.Length;
    }
    public int GetTurn()
    {
        return Turn;
    }
    public void TurnEnd() // 턴 오버 : 여기서 턴 엔드 이벤트 진행 << 추가할것들 여기서.
    {
        GameManager.instance.UImanager.SetStage();
        for (int i =0; i<point.Length;i++)
        {
            for(int j =0; j < point[i].childCount;j++)
            {
                point[i].GetChild(j).gameObject.GetComponent<Enemy>().MoveDown();
            }
        }
        if(Turn == MaxTurn)
        {
            return;
        }
        Turn++;
        // json stage에 따라 읽어들이기
        
        SpawnEnemy[0] = datas.Stage[Turn - 1].Point0;
        SpawnEnemy[1] = datas.Stage[Turn - 1].Point1;
        SpawnEnemy[2] = datas.Stage[Turn - 1].Point2;
        SpawnEnemy[3] = datas.Stage[Turn - 1].Point3;
        SpawnEnemy[4] = datas.Stage[Turn - 1].Point4;
        SpawnEnemy[5] = datas.Stage[Turn - 1].Point5;


        for (int i =0; i< SpawnEnemy.Length; i++)
        {
            if(SpawnEnemy[i] != 0)
            {
                GameManager.instance.objectpool.Get(SpawnEnemy[i], point[i]);
            }
            
        }
        //GameManager.instance.pathFind.StartFinding();
    }
}
