using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isMoving;
    public GameObject Bullets;
    public Rigidbody2D rigid;

    private void OnEnable()
    {
        Bullets = GameObject.Find("Bullets(Gun)");
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if(!isMoving)
        {
            gameObject.transform.position = Bullets.transform.position;
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
        if(collision.gameObject.CompareTag("End") && isMoving)
        {
            isMoving = false;
            gameObject.transform.position = Bullets.transform.position;
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
