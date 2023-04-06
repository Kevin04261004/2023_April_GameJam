using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int Hp;
    [SerializeField]
    private int CoolTime;
    [SerializeField]
    private Vector2 ThisVec2;

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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        HpDown();
    }
    public void MoveDown()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1);
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
