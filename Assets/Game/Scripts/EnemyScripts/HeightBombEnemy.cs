using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightBombEnemy : Enemy
{
    private Collider2D[] collider2Ds;

    public void OnEnable()
    {
        isSkillActive = true;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        CurCoolTime = CoolTime;
        gameObject.GetComponent<SpriteRenderer>().sprite = RealSprite;
        Turn_Image.gameObject.SetActive(true);
        BombSkill_Image.gameObject.SetActive(true);
        SetHpBarAndHp_TMP();
        SetTurn_TMP();
    }

    public override void Died()
    {
        base.Died();
        if (isSkillActive)
        {
            // �ı� ������ �ı� �ɶ�, �ֺ��� �������� ������ϴ�. << ���߿� �� ��ȹ���� �ɵ�.
            collider2Ds = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(0.4f, 10), 0);
            
            for (int i = 0; i < collider2Ds.Length; i++)
            {
                if (collider2Ds[i].gameObject.CompareTag("Enemy"))
                {
                    collider2Ds[i].gameObject.GetComponent<Enemy>().Died();
                }
            }
        }
    }
    public override void MoveDown()
    {
        base.MoveDown();
        CoolDown();
    }

}
