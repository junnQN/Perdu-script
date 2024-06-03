using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatReturnState : EnemyState
{
    private Enemy_Bat enemy;
    public BatReturnState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _enemy) : 
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.chargeTimer;
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
        
        if(enemy.transform.position != enemy.temp.transform.position && stateTimer < 0 )
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,
                enemy.temp.transform.position, enemy.moveSpeed  * Time.deltaTime);
            if(enemy.transform.position.x == enemy.temp.transform.position.x && 
               enemy.transform.position.y == enemy.temp.transform.position.y)
                stateMachine.ChangeState(enemy.idleState);
        }
    }
}
