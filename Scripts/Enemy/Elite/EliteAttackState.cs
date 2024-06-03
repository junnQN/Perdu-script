using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteAttackState : EnemyState
{
    private Enemy_Elite enemy;

    public EliteAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName,
        Enemy_Elite _enemy) :
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        
        enemy.atkCount++;
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();

        if (triggerCalled && enemy.atkCount < 3)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
        else if (triggerCalled && enemy.atkCount == 3)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
        else if(triggerCalled && enemy.atkCount > 3)
        {
            enemy.atkCount = 0;
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}