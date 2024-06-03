using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteIdleState : EliteGroundState
{
    public EliteIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Elite _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        enemy.rb.gravityScale = 12;
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();

        if (enemy.atkCount == 3 && stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.jumpState);
        }
    }
}