using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAirState : EnemyState
{
    protected Enemy_Bat enemy;
    protected Transform player;
    
    public BatAirState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _enemy) : 
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

        if (enemy.IsAirPlayerDetected())
        {
            stateMachine.ChangeState(enemy.battleState );
           
        }
    }
}
