using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int MaxHp;
    [SerializeField]
    protected int Hp;
    [SerializeField]
    protected int CurCoolTime;
    [SerializeField]
    protected int CoolTime = 3;
    [SerializeField]
    protected Vector2 ThisVec2;
    [SerializeField]
    protected bool isSkillActive = false;
    [SerializeField]
    protected Image image;
    [SerializeField]
    protected Sprite BaseSprite;
    [SerializeField]
    protected Sprite RealSprite;
    [SerializeField]
    protected Slider HpBar;
    [SerializeField]
    protected TextMeshProUGUI Hp_TMP;
    [SerializeField]
    protected TextMeshProUGUI Turn_TMP;
    [SerializeField]
    protected Image BombSkill_Image;
    [SerializeField]
    protected Image Turn_Image;
    private void OnEnable()
    {
        ThisVec2 = gameObject.transform.position;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        CurCoolTime = CoolTime;
        Turn_Image.gameObject.SetActive(true);
        SetHpBarAndHp_TMP();
        SetTurn_TMP();
        Turn_Image.gameObject.SetActive(false);
    }
    public int GetMaxHp()
    {
        return MaxHp;
    }
    public void HpDown(int _HowMuch =1)
    {
        Hp -= _HowMuch;
        SetHpBarAndHp_TMP();
        if (Hp <= 0)
        {
            Died();
        }
    }
    public virtual void Died()
    {
        gameObject.SetActive(false);
    }
    public virtual void MoveDown()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
    }
    public void CoolDown()
    {
        if(CurCoolTime == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BaseSprite;
            Turn_Image.gameObject.SetActive(false);
            if(BombSkill_Image != null)
            {
                BombSkill_Image.gameObject.SetActive(false);
            }
            isSkillActive = false;
            return;
        }
        CurCoolTime--;
        if (CurCoolTime <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BaseSprite;
            Turn_Image.gameObject.SetActive(false);
            if (BombSkill_Image != null)
            {
                BombSkill_Image.gameObject.SetActive(false);
            }
            isSkillActive = false;
        }
        SetTurn_TMP();
    }
    public void SetHpBarAndHp_TMP()
    {
        if(Hp == 0)
        {
            HpBar.value = 1 / 1;
            Hp_TMP.text = "1";
            return;
        }
        
        HpBar.value = (float)Hp / (float)MaxHp;
        Hp_TMP.text = Hp.ToString();
    }
    public void SetTurn_TMP()
    {
        Turn_TMP.text = CurCoolTime.ToString();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            HpDown();
            GameManager.instance.effectSoundManager.PopPlay();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("End"))
        {
            Died();
            GameManager.instance.player.HpDown();
        }
    }

}
