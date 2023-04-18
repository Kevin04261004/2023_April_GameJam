using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Transform Bullets;
    [SerializeField]
    private GameObject Player;
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
    private Vector3 gap;
    [SerializeField]
    private GameObject ballPreview;
    [SerializeField]
    private LineRenderer ballLineRenderer;
    [SerializeField]
    private Animator animator;
    public bool isEnd = false;
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
#if UNITY_STANDALONE_WIN
        if (CantShootTime)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-2.5f, -2.5f, 10);
            timeDelay = 0;
        }


        timeDelay += Time.deltaTime;
        if (timeDelay < 0.1f) return;
        bool isMouse = Input.GetMouseButton(0);

        if (Input.mousePosition.y <= 400)// 플레이어 움직일때는 리턴, y가 일정 거리 아래로 내려가면 미리보여주는 라인렌더러 0으로 초기화.
        {
            ballPreview.gameObject.SetActive(false);
            ballLineRenderer.SetPosition(0, Vector3.zero);
            ballLineRenderer.SetPosition(1, Vector3.zero);
            return;
        }
        if (isMouse)
        {
            secondPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(-2.5f, -2.5f, 10);
            if ((secondPos - firstPos).magnitude < 1)
            {
                return;
            }
            gap = (secondPos - firstPos).normalized;
            gap = new Vector3(gap.y >= 0 ? gap.x : gap.x >= 0 ? 1 : -1, Mathf.Clamp(gap.y, 0.2f, 1), 0); //

            ballPreview.gameObject.SetActive(true);


            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gap, 10000, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("Enemy"));

            ballLineRenderer.SetPosition(0, gameObject.transform.position);
            ballPreview.transform.position = (Vector3)hit.point - gap * 0.25f;
            ballLineRenderer.SetPosition(1, (Vector3)hit.point - gap * 0.25f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ShootAllBalls());

            ballLineRenderer.SetPosition(0, Vector3.zero);
            ballLineRenderer.SetPosition(1, Vector3.zero);
            CantShootTime = true;
            isEnd = false;
            GameManager.instance.player.InActiveChance();
        }
        ballPreview.SetActive(isMouse);
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            if (CantShootTime)
            {
                return;
            }

            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                int index = touch.fingerId;
                Vector2 position = touch.position;
                TouchPhase phase = touch.phase;

                if (touch.phase == TouchPhase.Began)
                {
                    firstPos = Camera.main.ScreenToWorldPoint(position) + new Vector3(-2.5f, -2.5f, 10);
                    timeDelay = 0;
                }

                timeDelay += Time.deltaTime;
                if (timeDelay < 0.1f) return;

                if (position.y <= 400)// 플레이어 움직일때는 리턴, y가 일정 거리 아래로 내려가면 미리보여주는 라인렌더러 0으로 초기화.
                {
                    ballPreview.gameObject.SetActive(false);
                    ballLineRenderer.SetPosition(0, Vector3.zero);
                    ballLineRenderer.SetPosition(1, Vector3.zero);
                    return;
                }

                if (Input.touchCount > 0)
                {
                    secondPos = Camera.main.ScreenToWorldPoint(position) + new Vector3(-2.5f, -2.5f, 10);
                    if ((secondPos - firstPos).magnitude < 1)
                    {
                        return;
                    }
                    gap = (secondPos - firstPos).normalized;
                    gap = new Vector3(gap.y >= 0 ? gap.x : gap.x >= 0 ? 1 : -1, Mathf.Clamp(gap.y, 0.2f, 1), 0); //

                    ballPreview.gameObject.SetActive(true);


                    RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gap, 10000, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("Enemy"));

                    ballLineRenderer.SetPosition(0, gameObject.transform.position);
                    ballPreview.transform.position = (Vector3)hit.point - gap * 0.25f;
                    ballLineRenderer.SetPosition(1, (Vector3)hit.point - gap * 0.25f);
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    StartCoroutine(ShootAllBalls());

                    ballLineRenderer.SetPosition(0, Vector3.zero);
                    ballLineRenderer.SetPosition(1, Vector3.zero);
                    CantShootTime = true;
                    isEnd = false;
                    GameManager.instance.player.InActiveChance();
                }
            }
        }
        if (Input.touchCount > 0)
        {
            ballPreview.SetActive(true);
        }
        else
        {
            ballPreview.SetActive(false);
        }
#endif
    }

    public void isTurnEnd() // 모든 공이 움직이지 않을 때, 쏠 수 없을때, 쏠 수 있게 바꿔야함.
    {
        for (int i = 0; i < Bullets.childCount; i++)
        {
            if (Bullets.GetChild(i).GetComponent<Ball>().isMoving || !CantShootTime)
            {
                return;
            }
        }
        CantShootTime = false;
        Bullets.transform.position = Player.transform.position + new Vector3(0, Bullets.transform.position.y, 0);
        GameManager.instance.player.SetBulletToMaxBullet();
        GameManager.instance.spawnWave.TurnEnd();
    }
    IEnumerator ShootAllBalls()
    {
        for (int i = 0; i < Bullets.childCount; i++)
        {
            animator.SetBool("isShooting", true);
            GameManager.instance.player.Bullet--;
            GameManager.instance.UImanager.SetBallHowMuch(GameManager.instance.player.Bullet);
            Rigidbody2D bulletRigidbody = Bullets.GetChild(i).GetComponent<Rigidbody2D>();
            if (gap != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, gap.normalized);
                Bullets.GetChild(i).transform.rotation = rotation;
            }
            Vector3 velocity = new Vector3(gap.x, gap.y, 1f).normalized * Speed;
            bulletRigidbody.velocity = velocity;
            Bullets.GetChild(i).GetComponent<Ball>().isMoving = true;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForEndOfFrame();
        animator.SetBool("isShooting", false);
    }


}
