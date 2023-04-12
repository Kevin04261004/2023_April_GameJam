using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusEnemy : Enemy
{
    [SerializeField]
    private Transform Bullets;
    public void Awake()
    {
        Bullets = GameObject.Find("Bullets(Gun)").transform;
    }
    private void OnEnable()
    {
        isSkillActive = true;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        SetHpBarAndHp_TMP();
    }
    //�÷��� ������ �ı�������, ������ �߰��� ����ϴ�.
    public override void Died()
    {
        base.Died();
        if (isSkillActive)
        {
            GameManager.instance.objectpool.Get(0, Bullets);
        }
    }
    public override void MoveDown()
    {
        base.MoveDown();
        CoolDown();
    }
}
