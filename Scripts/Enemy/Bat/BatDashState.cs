using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDashState : EnemyState
{
    private Enemy_Bat enemy;
    private Transform player;
    private Vector3 direction;
    
    public BatDashState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _enemy) :
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
        
        player = GameObject.Find("Player").transform;
        
        direction = player.transform.position - enemy.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsGroundDetected() || enemy.IsWallDetected())
        {
            enemy.SetZeroVelocity();
            stateMachine.ChangeState(enemy.returnState);
        }
        else
        {
            enemy.rb.velocity = new Vector2(direction.x, direction.y).normalized * enemy.dashSpeed;
        }
    }                             
}
