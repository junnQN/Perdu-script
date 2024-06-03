using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteDeadState : EnemyState
{
    private Enemy_Elite enemy;
    
    public EliteDeadState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Elite _enemy) : 
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
        
        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed = 0f;
        enemy.cd.enabled = false;
        
        stateTimer = .15f;
    }

    public override void Update()
    {
        base.Update();
        
        if(stateTimer>0)
            rb.velocity = new Vector2(0f,10);

    }
}
