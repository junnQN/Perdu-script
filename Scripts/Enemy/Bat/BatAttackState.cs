using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackState : EnemyState
{
    private Enemy_Bat enemy;
    private Transform player;
   
    
    public BatAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _enemy) : 
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        
        player = GameObject.Find("Player").transform;
        
        stateTimer = enemy.chargeTimer;
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
            
            if (stateTimer < 0)
            {
                
                stateMachine.ChangeState(enemy.dashState);
            }
    }
}
