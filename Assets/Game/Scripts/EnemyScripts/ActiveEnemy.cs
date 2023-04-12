using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : Enemy
{
    // 행동 벽돌은 죽었을떄 플레이어가 한번 더 공을 쏠 수 있습니다.
    private void OnEnable()
    {
        isSkillActive = true;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        SetHpBarAndHp_TMP();
        SetTurn_TMP();
    }
    public override void Died()
    {
        base.Died();
        if (isSkillActive)
        {
            GameManager.instance.shoot.ActiveChance();
        }
    }
    public override void MoveDown()
    {
        base.MoveDown();
        CoolDown();
    }
}
