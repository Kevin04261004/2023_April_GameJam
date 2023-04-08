using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Stage_TMP; // SetStage()
    [SerializeField]
    private Image[] Hp_Image; // 
    [SerializeField]
    private TextMeshProUGUI Ball_TMP; // SetBallHowMuch()
    [SerializeField]
    private Button Setting_Btn; // OnClickSetting_Btn()
    [SerializeField]
    private Image GameOverBackGround_Image; // GameOverSetTrue()
    [SerializeField]
    private TextMeshProUGUI GameOver_MyScore_TMP; // GameOverUI()
    [SerializeField]
    private Button Retry_Btn; // OnClick_Setting_Retry_Btn()
    [SerializeField]
    private Button Exit_Btn; // OnClickExit_Btn()
    [SerializeField]
    private Image OptionBackGround_Image; // OnClickSetting_Btn()
    [SerializeField]
    private Image RealExitBackGround_Image; // OnClickExit_Btn()
    [SerializeField]
    private Button Exit_No_Btn; // OnClickExit_No()
    [SerializeField]
    private Button Exit_Yes_Btn; // OnClickExit_Yes()
    private void Start()
    {
        Time.timeScale = 1;
        Stage_TMP.text = "Stage 0";
        Ball_TMP.text = "x 1";
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickExit_Btn();
        }
    }
    public void SetStage()
    {
        Stage_TMP.text = "Stage " + (GameManager.instance.spawnWave.GetTurn() + 1).ToString();
    }
    public void SetHp_Image()
    {
        Hp_Image[GameManager.instance.player.GetCurHp()].gameObject.SetActive(false);
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
    public void OnClickSetting_Btn()
    {
        Time.timeScale = 0;
        OptionBackGround_Image.gameObject.SetActive(true);
    }
    public void OnClick_Setting_Retry_Btn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickSetting_Continue_Btn()
    {
        Time.timeScale = 1;
        OptionBackGround_Image.gameObject.SetActive(false);
    }
    public void OnClickExit_Btn()
    {
        RealExitBackGround_Image.gameObject.SetActive(true);
    }
    public void OnClickExit_Yes()
    {
        Application.Quit();
    }
    public void OnClickExit_No()
    {
        RealExitBackGround_Image.gameObject.SetActive(false);
    }
}