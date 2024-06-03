using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy_Bat : Enemy
{
    public int damageAmount = 10;
    
    private Transform player;

    private float distance;
    public float firstDistance;

    public float chargeTimer=1f;
    public float dashSpeed = 10f;
    public Transform temp;
   
    
    #region States
    public BatIdleState idleState { get; private set; }
    public BatMoveState moveState { get; private set; }
    public BatBattleState battleState { get; private set; }
    public BatAttackState attackState {get; private set; }
    public BatDashState dashState { get; private set; }
    public BatReturnState returnState { get; private set; }
    
    #endregion
    
    
    protected override void Awake()
    {
        base.Awake();

        idleState = new BatIdleState(this, stateMachine, "Idle", this);
        moveState = new BatMoveState(this, stateMachine, "Move", this);
        battleState = new BatBattleState(this, stateMachine, "Move", this);
        attackState = new BatAttackState(this, stateMachine, "Idle", this);
        dashState = new BatDashState(this, stateMachine, "Move", this);
        returnState = new BatReturnState(this, stateMachine, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        
        stateMachine.Initialize(idleState);

        player = GameObject.Find("Player").transform;
    }

    protected override void Update()
    {
        base.Update();
        

    }

    public virtual RaycastHit2D IsAirPlayerDetected() =>
        Physics2D.CircleCast(wallCheck.position, 7f, Vector2.right * facingDir,
            0f,whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        //Gizmos.DrawWireSphere(wallCheck.position,7f);
    }

    private void OnTriggerEnter2D(Collider2D _other)
    {
        if (_other.gameObject.CompareTag("Player"))
        {
            if (_other.gameObject.GetComponent<Player>() != null)
            {
                PlayerStats target = _other.gameObject.GetComponent<PlayerStats>();
                target.TakeDamage(damageAmount);
            }
        }
    }

    public override void Die()
    {
        base.Die();
        
        Destroy(gameObject);
    }
}
