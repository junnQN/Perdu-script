using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteBattleState : EnemyState
{
    private Enemy_Elite enemy;
    private Transform player;
    private int moveDir;
    
    public EliteBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Elite _enemy) : 
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
        
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;
            
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if(stateTimer < 0 || Vector2.Distance(player.transform.position, 
                                  enemy.transform.position) > 7 )
                stateMachine.ChangeState(enemy.idleState);
        }

        if(player.position.x < enemy.transform.position.x)
            moveDir = -1;
        else if(player.position.x > enemy.transform.position.x)
            moveDir = 1;
        
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        
        return false;
    }
}