using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : Enemy
{
    // �ൿ ������ �׾����� �÷��̾ �ѹ� �� ���� �� �� �ֽ��ϴ�.
    private void OnEnable()
    {
        isSkillActive = true;
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
