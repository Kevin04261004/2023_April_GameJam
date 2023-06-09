using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isMoving;
    public GameObject Bullets;
    public GameObject Player;
    public Rigidbody2D rigid;

    private void OnEnable()
    {
        Bullets = GameObject.Find("Bullets(Gun)");
        Player = GameObject.Find("Player");
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if(!isMoving)
        {
            gameObject.transform.position = Player.transform.position + new Vector3(0,Bullets.transform.position.y,0);
        }
    }
    public void isMovingTrue()
    {
        if(isMoving)
        {
            return;
        }
        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rigid.velocity.normalized);
        gameObject.transform.rotation = rotation;

        if(collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.player.myPointUp(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End") && isMoving)
        {
            if (GameManager.instance.shoot.isEnd == false)
            {
                Vector3 playerPos = GameManager.instance.player.transform.position;
                playerPos.x = gameObject.transform.position.x;
                GameManager.instance.player.transform.position = playerPos;
                GameManager.instance.shoot.isEnd = true;
            }

            isMoving = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
