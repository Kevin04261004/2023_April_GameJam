//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;

//public class GoogleSheetManager : MonoBehaviour
//{
//    [SerializeField]
//    private const string URL = "https://docs.google.com/spreadsheets/d/1EJ_m0wSLycdbVwiPNuk1MlLEsXF9vzeDUIBkZ_vKwTI/export?format=tsv";
//    [SerializeField]
//    private string data;
//    [SerializeField]
//    private Transform[] point;
//    public int Turn = 0;
//    public AllData datas;
//    public int[] SpawnEnemy;
//    IEnumerator GetURL()
//    {
//        UnityWebRequest www = UnityWebRequest.Get(URL);
//        yield return www.SendWebRequest();

//        data = www.downloadHandler.text;
//        print(data);
//    }
//    private void Awake()
//    {
//        StartCoroutine(GetURL());
//    }
//    private void Start()
//    {
//        GameManager.instance.objectpool.Get(1, point[0]);
//        SpawnEnemy = new int[6];
//        Turn = 0;
//        //datas = 
//    }
//    public int GetTurn()
//    {
//        return Turn;
//    }
//    public void TurnEnd() // 턴 오버 : 여기서 턴 엔드 이벤트 진행 << 추가할것들 여기서.
//    {
//        GameManager.instance.UImanager.SetStage();
//        for (int i = 0; i < point.Length; i++)
//        {
//            for (int j = 0; j < point[i].childCount; j++)
//            {
//                point[i].GetChild(j).gameObject.GetComponent<Enemy>().MoveDown();
//            }
//        }
//        Turn++;
//        // json stage에 따라 읽어들이기

//        SpawnEnemy[0] = datas.Stage[Turn - 1].Point0;
//        SpawnEnemy[1] = datas.Stage[Turn - 1].Point1;
//        SpawnEnemy[2] = datas.Stage[Turn - 1].Point2;
//        SpawnEnemy[3] = datas.Stage[Turn - 1].Point3;
//        SpawnEnemy[4] = datas.Stage[Turn - 1].Point4;
//        SpawnEnemy[5] = datas.Stage[Turn - 1].Point5;


//        for (int i = 0; i < SpawnEnemy.Length; i++)
//        {
//            if (SpawnEnemy[i] != 0)
//            {
//                GameManager.instance.objectpool.Get(SpawnEnemy[i], point[i]);
//            }

//        }
//        GameManager.instance.pathFind.StartFinding();
//    }
//}
