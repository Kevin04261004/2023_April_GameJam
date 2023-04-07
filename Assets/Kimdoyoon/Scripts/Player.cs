using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int Health =3;
    [SerializeField]
    private int CurHp = 3;
    [SerializeField]
    private Transform Bullets;

    private void Awake()
    {
        CurHp = Health;
    }
    private void Start()
    {
        GameManager.instance.objectpool.Get(0, Bullets);
    }
    private void Update()
    {
        MouseOnPlayer(); //캐릭터 이동.
    }
    public int GetCurHp()
    {
        return CurHp;
    }
    public Transform GetBullets()
    {
        return Bullets;
    }
    public void HpDown(int _howMuch = 1)
    {
        CurHp -= _howMuch;
        if(CurHp <=0)
        {
            Died();
        }
    }
    public void Died()
    {
        Debug.Log("게임오버");
    }
    public void MouseOnPlayer()
    {
        if (Input.GetMouseButton(0) && GameManager.instance.shoot.GetCanActiveTime())
        {
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            Vector2 point = Camera.main.ScreenToWorldPoint(new Vector2(mouseX, mouseY));

            foreach (Collider2D col in Physics2D.OverlapBoxAll(point, new Vector2(0.2f, 0.2f),0))
                if (col.gameObject == this.gameObject)
                {
                    if (point.x > 0.1 && point.x < 4.9) 
                        col.gameObject.transform.position = new Vector3(point.x,-2,0);
                }

        }
    }
}