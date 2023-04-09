using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDownEnemy : Enemy
{
    // ü�°��� ������ �ı��ɶ�, �÷��̾��� ü���� �����մϴ�.
    [SerializeField]
    private int damage;

    public override void Died()
    {
        base.Died();
        GameManager.instance.player.HpDown(damage);
    }
}
