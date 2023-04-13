using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int MaxHp =3;
    [SerializeField]
    private int CurHp = 3;
    public int Bullet;
    [SerializeField]
    private Transform Bullets;
    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        CurHp = MaxHp;
    }
    private void Start()
    {
        GameManager.instance.objectpool.Get(0, Bullets);
    }
    private void Update()
    {
        MouseOnPlayer(); //캐릭터 이동.
    }
    public int GetMaxHp()
    {
        return MaxHp;
    }
    public int GetCurHp()
    {
        return CurHp;
    }
    public Transform GetBullets()
    {
        return Bullets;
    }
    public void HpDown(int _howMuch = 1) // 체력 깍이기.
    {
        if (CurHp-_howMuch <= 0)
        {
            Died();
            CurHp -= _howMuch;
            if(CurHp >-1)
            {
                GameManager.instance.UImanager.SetHp_Image();
            }
            return;

        }
        CurHp -= _howMuch;
        GameManager.instance.UImanager.SetHp_Image();
    }
    public void Died()
    {
        animator.SetBool("isPlayerDie", true);
        StartCoroutine(DiedCoroutine());
    }
    IEnumerator DiedCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.UImanager.GameOverUI();
        Time.timeScale = 0;
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
    public void SetBulletToMaxBullet()
    {
        Bullet = Bullets.childCount;
        GameManager.instance.UImanager.SetBallHowMuch(Bullet);
    }
}