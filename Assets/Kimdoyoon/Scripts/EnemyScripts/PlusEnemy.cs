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
    public override void Died()
    {
        base.Died();
        GameManager.instance.objectpool.Get(0, Bullets) ;
    }
}
