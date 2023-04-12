using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : Enemy
{
    // �ൿ ������ �׾����� �÷��̾ �ѹ� �� ���� �� �� �ֽ��ϴ�.
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
