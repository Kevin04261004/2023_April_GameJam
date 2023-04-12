using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    private Collider2D[] collider2Ds;
    private void OnEnable()
    {
        isSkillActive = true;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        SetHpBarAndHp_TMP();
    }
    public override void Died()
    {
        base.Died();
        if (isSkillActive)
        {
            // �ı� ������ �ı� �ɶ�, �ֺ��� �������� ������ϴ�. << ���߿� �� ��ȹ���� �ɵ�.
            collider2Ds = Physics2D.OverlapCircleAll(gameObject.transform.position, 1f, LayerMask.GetMask("Enemy"));
            for (int i = 0; i < collider2Ds.Length; i++)
            {
                collider2Ds[i].gameObject.GetComponent<Enemy>().Died();
            }
        }
    }
    public override void MoveDown()
    {
        base.MoveDown();
        CoolDown();
    }
}
