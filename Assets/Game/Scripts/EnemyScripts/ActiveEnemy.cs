using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : Enemy
{
    // 행동 벽돌은 죽었을떄 플레이어가 한번 더 공을 쏠 수 있습니다.
    public override void Died()
    {
        base.Died();
        GameManager.instance.shoot.ActiveChance();
    }
}
