using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusEnemy : Enemy
{
    [SerializeField]
    private Transform Bullets;
    private void OnEnable()
    {
        Bullets = GameObject.Find("Bullets(Gun)").transform;
        isSkillActive = true;
        Hp = GameManager.instance.spawnWave.Turn;
        MaxHp = Hp;
        CurCoolTime = CoolTime;
        gameObject.GetComponent<SpriteRenderer>().sprite = RealSprite;
        Turn_Image.gameObject.SetActive(true);
        SetHpBarAndHp_TMP();
        SetTurn_TMP();
        Turn_Image.gameObject.SetActive(false);
    }
    //플러스 벽돌은 파괴됬을때, 씨앗을 추가로 얻습니다.
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
