using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEnemy : Enemy
{
    // �ൿ ������ �׾����� �÷��̾ �ѹ� �� ���� �� �� �ֽ��ϴ�.
    public override void Died()
    {
        base.Died();
        GameManager.instance.shoot.ActiveChance();
    }
}
