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
    //플러스 벽돌은 파괴됬을때, 씨앗을 추가로 얻습니다.
    public override void Died()
    {
        base.Died();
        GameManager.instance.objectpool.Get(0, Bullets);
    }
}
