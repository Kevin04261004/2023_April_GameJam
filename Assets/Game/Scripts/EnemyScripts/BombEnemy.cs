using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    private Collider2D[] collider2Ds;
    private void OnEnable()
    {
        isSkillActive = true;
    }
    public override void Died()
    {
        base.Died();
        if (isSkillActive)
        {
            // 파괴 벽돌은 파괴 될때, 주변의 벽돌들이 사라집니다. << 나중에 상세 기획보면 될듯.
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
