using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDownEnemy : Enemy
{
    // ü�°��� ������ �ı��ɶ�, �÷��̾��� ü���� �����մϴ�.
    [SerializeField]
    private int damage;
    private void OnEnable()
    {
        isSkillActive = true;
    }
    public override void Died()
    {
        base.Died();
        if(isSkillActive)
        {
            GameManager.instance.player.HpDown(damage);
        }
    }
    public override void MoveDown()
    {
        base.MoveDown();
        CoolDown();
    }
}
