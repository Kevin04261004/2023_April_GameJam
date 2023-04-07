using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    public override void Died()
    {
        base.Died();
        // 주변 3*3에게 피해를 준다.
    }
}
