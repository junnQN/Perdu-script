using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteJumpState : EnemyState
{
    private Enemy_Elite enemy;
    
    public EliteJumpState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Elite _enemy) :
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
        
        if (!enemy.isHopping)
        {
            stateTimer = enemy.idleTime;
            enemy.isHopping = true;
            rb.gravityScale = 1;
            if (enemy.facingDir == 1)
                rb.velocity = new Vector2(-1 * enemy.jumpForcex, enemy.jumpForcey);
            else if(enemy.facingDir == -1)
                rb.velocity = new Vector2(enemy.jumpForcex, enemy.jumpForcey);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.isHopping && enemy.IsGroundDetected() && stateTimer < 0)
        {
            enemy.isHopping = false;
            if (enemy.isHopping==false)
            {
                enemy.HopAndGenerateShockwaves();
                enemy.atkCount = 0;
                stateMachine.ChangeState(enemy.idleState);
            }
        }
        
    }
}
