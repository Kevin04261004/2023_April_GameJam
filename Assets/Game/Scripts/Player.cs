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
    [SerializeField]
    private int myPoint = 0;
    [SerializeField]
    private bool activeChance = false;
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
    public int GetmyPoint()
    {
        return myPoint;
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
    public void myPointUp(int _howMuch = 1)
    {
        myPoint += _howMuch;
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
        GameManager.instance.bgmManager.DeadBGMPlay();
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
#if UNITY_STANDALONE_WIN
        if (Input.GetMouseButton(0) && GameManager.instance.shoot.GetCanActiveTime())
        {
            if (!activeChance)
            {
                return;
            }

            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            Vector2 point = Camera.main.ScreenToWorldPoint(new Vector2(mouseX, mouseY));
            foreach (Collider2D col in Physics2D.OverlapBoxAll(point, new Vector2(0.2f, 0.2f),0))
                if (col.gameObject == this.gameObject)
                {
                    if (point.x > -5.25 && point.x < 0)
                    {
                        col.gameObject.transform.position = new Vector3(point.x, gameObject.transform.position.y, 0);
                        Bullets.transform.position = gameObject.transform.position + new Vector3(0, Bullets.transform.position.y, 0);
                    }
                }

        }
#elif UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            for(int i = 0; i< Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                int index = touch.fingerId;
                Vector2 position = touch.position;
                TouchPhase phase = touch.phase;
                if (phase == TouchPhase.Moved && GameManager.instance.shoot.GetCanActiveTime())
                {
                    if (!activeChance)
                    {
                        return;
                    }

                    Vector2 point = Camera.main.ScreenToWorldPoint(position);
                    print(point);
                    foreach (Collider2D col in Physics2D.OverlapBoxAll(point, new Vector2(0.2f, 0.2f), 0))
                        if (col.gameObject == this.gameObject)
                        {
                            if (point.x > -5.25 && point.x < 0)
                            {
                                col.gameObject.transform.position = new Vector3(point.x, gameObject.transform.position.y, 0);
                                Bullets.transform.position = gameObject.transform.position + new Vector3(0, Bullets.transform.position.y, 0);
                            }
                        }
                }
            }
        }
#endif
    }
    public void SetBulletToMaxBullet()
    {
        Bullet = Bullets.childCount;
        GameManager.instance.UImanager.SetBallHowMuch(Bullet);
    }

    public void ActiveChance()
    {
        activeChance = true;
    }

    public void InActiveChance()
    {
        activeChance = false;
    }
}