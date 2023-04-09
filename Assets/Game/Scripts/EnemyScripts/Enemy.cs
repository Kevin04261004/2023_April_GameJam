using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int Hp;
    [SerializeField]
    protected int CoolTime = 3;
    [SerializeField]
    protected Vector2 ThisVec2;
    [SerializeField]
    protected bool isSkillActive = false;

    private void OnEnable()
    {
        ThisVec2 = gameObject.transform.position;
        Hp = GameManager.instance.spawnWave.Turn;
    }
    public void HpDown(int _HowMuch =1)
    {
        Hp -= _HowMuch;
        if(Hp <= 0)
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
            isSkillActive = false;
            return;
        }
        CoolTime--;
        if (CoolTime <= 0)
        {
            isSkillActive = false;
        }
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
