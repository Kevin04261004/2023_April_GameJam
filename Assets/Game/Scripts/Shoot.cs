using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private Vector3 gap;
    [SerializeField]
    private GameObject ballPreview;
    [SerializeField]
    private LineRenderer ballLineRenderer;
    [SerializeField]
    private bool activeChance;
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
            timeDelay = 0;
        }


        timeDelay += Time.deltaTime;
        if (timeDelay < 0.3f) return;
        bool isMouse = Input.GetMouseButton(0);
        if (Input.mousePosition.y <= 180)// �÷��̾� �����϶��� ����, y�� ���� �Ÿ� �Ʒ��� �������� �̸������ִ� ���η����� 0���� �ʱ�ȭ.
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
            gap = new Vector3(gap.y >= 0 ? gap.x : gap.x >= 0 ? 1 : -1, Mathf.Clamp(gap.y, 0.2f, 1), 0);

            ballPreview.gameObject.SetActive(true);
            ballPreview.transform.position =
               Physics2D.CircleCast(new Vector2(Mathf.Clamp(gameObject.transform.position.x, -0.5f, 5.5f), -1f), 0.15f, gap, 10000, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("Enemy")).centroid; // 1.8

            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, gap, 10000, 1 << LayerMask.NameToLayer("Wall") | 1 << LayerMask.NameToLayer("Enemy"));

            ballLineRenderer.SetPosition(0, gameObject.transform.position);
            ballLineRenderer.SetPosition(1, (Vector3)hit.point - gap * 0.25f);
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            StartCoroutine(ShootAllBalls());

            ballLineRenderer.SetPosition(0, Vector3.zero);
            ballLineRenderer.SetPosition(1, Vector3.zero);
            CantShootTime = true;
        }
        ballPreview.SetActive(isMouse);
    }
    public void isTurnEnd() // ��� ���� �������� ���� ��, �� �� ������, �� �� �ְ� �ٲ����.
    {
        for (int i = 0; i < Bullets.childCount; i++)
        {
            if (Bullets.GetChild(i).GetComponent<Ball>().isMoving || !CantShootTime)
            {
                return;
            }
        }
        CantShootTime = false;

        if (activeChance == true)
        {
            activeChance = false;
            return;
        }

        GameManager.instance.spawnWave.TurnEnd();
    }
    IEnumerator ShootAllBalls()
    {
        for (int i = 0; i < Bullets.childCount; i++) 
        {
            Bullets.GetChild(i).GetComponent<Rigidbody2D>().AddForce(gap.normalized * Speed);//�ӷ� �Ȱ��� �ؼ� ������
            Bullets.GetChild(i).GetComponent<Ball>().isMoving = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ActiveChance()
    {
        activeChance = true;
    }
}
