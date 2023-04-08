using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    public override void Died()
    {
        base.Died();
        // 파괴 벽돌은 파괴 될때, 주변의 벽돌들이 사라집니다. << 나중에 상세 기획보면 될듯.
    }
}
