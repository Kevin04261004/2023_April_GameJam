using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDownEnemy : Enemy
{
    // 체력감소 벽돌은 파괴될때, 플레이어의 체력이 감소합니다.
    [SerializeField]
    private int damage;

    public override void Died()
    {
        base.Died();
        GameManager.instance.player.HpDown(damage);
    }
}
