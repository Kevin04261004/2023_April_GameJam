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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("End") && isMoving)
        {
            isMoving = false;
            gameObject.transform.position = Bullets.transform.position;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
