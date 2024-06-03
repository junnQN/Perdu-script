using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteGroundState : EnemyState
{
    protected Enemy_Elite enemy;
    protected Transform player;
    
    public EliteGroundState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Elite _enemy) :
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

        if (enemy.IsPlayerDetected() ||
            Vector2.Distance(player.transform.position, enemy.transform.position) < 4)
            stateMachine.ChangeState(enemy.battleState);
    }
}
