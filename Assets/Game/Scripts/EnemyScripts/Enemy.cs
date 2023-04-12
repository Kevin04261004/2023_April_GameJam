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
    protected int CoolTime = 3;
    [SerializeField]
    protected Vector2 ThisVec2;
    [SerializeField]
    protected bool isSkillActive = false;
    [SerializeField]
    protected Sprite BaseSprite;
    [SerializeField]
    protected Slider HpBar;
    [SerializeField]
    protected TextMeshProUGUI Hp_TMP;
    private void OnEnable()
    {

        ThisVec2 = gameObject.transform.position;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        SetHpBarAndHp_TMP();
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
        if(CoolTime == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            isSkillActive = false;
            return;
        }
        CoolTime--;
        if (CoolTime <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            isSkillActive = false;
        }
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
