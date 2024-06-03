using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatBattleState :  EnemyState
{
    private Transform player;
    private Enemy_Bat enemy;
    private float distance;
    
    public BatBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Bat _enemy) : 
        base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
        enemy.firstDistance = Vector2.Distance(player.transform.position, enemy.transform.position);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        
        
        if (Vector2.Distance(player.transform.position, enemy.transform.position)  < enemy.firstDistance*0.75)
        {
                stateMachine.ChangeState(enemy.attackState);
        }
        else 
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,
                player.transform.position, enemy.moveSpeed * 2f * Time.deltaTime);
        }
    }
}
