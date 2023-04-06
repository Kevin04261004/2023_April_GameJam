using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform Bullets;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private bool CantShootTime;
    [SerializeField]
    private bool CanActiveTime;
    [SerializeField]
    private Vector2 firstPos;
    [SerializeField]
    private Vector2 secondPos;
    [SerializeField]
    private float timeDelay;
    [SerializeField]
    private Vector2 gap;
    private void Update()
    {
        CanActiveTime = true;
        if (CantShootTime)
        {
            CanActiveTime = false;
        }
        Shooting();
        isTurnEnd();
    }
    public bool GetCanActiveTime()
    {
        return CanActiveTime;
    }
    public void Shooting()
    {
        if(CantShootTime)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-2.5f, -2.5f, 10);
            print(firstPos);
            timeDelay = 0;
        }


        timeDelay += Time.deltaTime;
        if (timeDelay < 0.3f) return;
        bool isMouse = Input.GetMouseButton(0);
        if (Input.mousePosition.y <= 180)// 플레이어 움직일때는 리턴.
        {
            return;
        }
        if (isMouse)
        {
            secondPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-2.5f, -2.5f, 10);
            if ((secondPos - firstPos).magnitude < 1) return;

            gap = (secondPos - firstPos).normalized;
            gap = new Vector3(gap.y >= 0 ? gap.x : gap.x >= 0 ? 1 : -1, Mathf.Clamp(gap.y, 0.2f, 1), 0);

        }
        if (Input.GetMouseButtonUp(0)) 
        {
            Bullets.GetChild(0).GetComponent<Rigidbody2D>().AddForce(gap.normalized * Speed);//속력 똑같이 해서 날리기
            Bullets.GetChild(0).GetComponent<Ball>().isMoving = true;
            CantShootTime = true;
        }

    }
    public void isTurnEnd()
    {
        if (!Bullets.GetChild(Bullets.childCount-1).GetComponent<Ball>().isMoving && CantShootTime)
        {
            CantShootTime = false;
            GameManager.instance.spawnWave.TurnEnd();
        }
    }
}
