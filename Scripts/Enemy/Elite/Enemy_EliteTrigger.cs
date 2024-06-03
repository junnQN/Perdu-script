using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_EliteTrigger : Enemy_AnimationTriggers
{
    private Enemy_Elite enemyElite => GetComponentInParent<Enemy_Elite>();

   

    private void MakeInvisible() => enemyElite.fx.MakeTransparent(true);
    
    private void MakeVisible() => enemyElite.fx.MakeTransparent(false);
}
