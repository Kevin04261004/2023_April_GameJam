using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isMoving;
    public GameObject Bullets;
    private void OnEnable()
    {
        Bullets = GameObject.Find("Bullets(Gun)");
    }
    public void isMovingTrue()
    {
        if(isMoving)
        {
            return;
        }
        isMoving = true;
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
