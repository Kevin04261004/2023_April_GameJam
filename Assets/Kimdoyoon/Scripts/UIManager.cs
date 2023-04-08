using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Stage_TMP; //SetStage()
    [SerializeField]
    private Image[] Hp_Image; //
    [SerializeField]
    private TextMeshProUGUI Ball_TMP; //SetBallHowMuch()
    [SerializeField]
    private Button Setting_Btn;
    [SerializeField]
    private Image GameOverBackGround_Image; // GameOverSetTrue()
    [SerializeField]
    private TextMeshProUGUI GameOver_MyScore_TMP;
    [SerializeField]
    private Button Retry_Btn;
    [SerializeField]
    private Button Exit_Btn;
    [SerializeField]
    private Image OptionBackGround_Image;
    private void Start()
    {
        Stage_TMP.text = "Stage 0";
        Ball_TMP.text = "x 1";
    }
    public void SetStage()
    {
        Stage_TMP.text = "Stage " + (GameManager.instance.spawnWave.GetTurn() + 1).ToString();
    }
    public void SetBallHowMuch()
    {
        Ball_TMP.text = "x " + GameManager.instance.player.GetBullets().childCount.ToString();
    }
    public void GameOverUI()
    {
        GameOverBackGround_Image.gameObject.SetActive(true);
        GameOver_MyScore_TMP.text = "Score : " + (GameManager.instance.spawnWave.GetTurn() + 1).ToString();
    }
}
