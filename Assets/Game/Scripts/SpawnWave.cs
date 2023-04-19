using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class AllData
{
    public StageData[] Stage;
    public AllData(int length)
    {
        Stage = new StageData[length];
    }
}
[System.Serializable]
public class StageData
{
    public int StageID;
    public int Point0;
    public int Point1;
    public int Point2;
    public int Point3;
    public int Point4;
    public int Point5;
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
    const string URL = "https://docs.google.com/spreadsheets/d/1EJ_m0wSLycdbVwiPNuk1MlLEsXF9vzeDUIBkZ_vKwTI/export?format=tsv&range=A2:G";//&gid를 추가하여, 다른 시트도 추가할 수 있다.

    private void Start()
    {
        StartCoroutine(ReadSCV());

        GameManager.instance.objectpool.Get(1, point[0]);
        SpawnEnemy = new int[6];
        Turn = 0;
    }

    IEnumerator ReadSCV()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        print(data);
        SetStage(data);
    }
    void SetStage(string tsv)
    {
        string[] row = tsv.Split('\n');
        MaxTurn = row.Length;
        datas = new AllData(MaxTurn);
        for (int i = 0; i < MaxTurn; i++)
        {
            string[] column = row[i].Split('\t');
            datas.Stage[i] = new StageData();
            datas.Stage[i].StageID = int.Parse(column[0]);
            datas.Stage[i].Point0 = int.Parse(column[1]);
            datas.Stage[i].Point1 = int.Parse(column[2]);
            datas.Stage[i].Point2 = int.Parse(column[3]);
            datas.Stage[i].Point3 = int.Parse(column[4]);
            datas.Stage[i].Point4 = int.Parse(column[5]);
            datas.Stage[i].Point5 = int.Parse(column[6]);

        }

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
