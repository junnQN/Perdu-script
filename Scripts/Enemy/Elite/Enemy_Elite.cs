using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Elite : Enemy
{
    #region States
    public EliteIdleState idleState { get; private set; }
    public EliteMoveState moveState { get; private set; }
    public EliteBattleState battleState { get; private set; }
    public EliteAttackState attackState{ get; private set; }
    public EliteJumpState jumpState { get; private set; }
    public EliteDeadState deadState { get; private set; }
    #endregion
    
    public float jumpForcex;
    public float jumpForcey;
    public int atkCount=0;
    
    public GameObject shockwavePrefab;
    [SerializeField] float shockWaveSpeed = 10f;
    public float shockwaveDuration = 1.0f;
    public bool isHopping=false;
    public float hopForce = 5.0f;
    [SerializeField] private GameObject shockWaveSpawn;
    
    protected override void Awake()
    {
        base.Awake();

        idleState = new EliteIdleState(this, stateMachine, "Idle", this);
        moveState = new EliteMoveState(this, stateMachine, "Move", this);
        battleState = new EliteBattleState(this, stateMachine, "Move", this);
        attackState = new EliteAttackState(this, stateMachine, "Attack", this);
        jumpState = new EliteJumpState(this, stateMachine, "Move", this);
        deadState = new EliteDeadState(this, stateMachine, "Idle", this);
    }

    protected override void Start()
    {
        base.Start();
        
        stateMachine.Initialize(idleState);
    }
    
    protected override void Update()
    {
        base.Update();
    }
    
    public override void Die()
    {
        base.Die();
        
        stateMachine.ChangeState(deadState);
    }

    

    private RaycastHit2D GroundBelow() => Physics2D.Raycast(transform.position, Vector2.down,
        100, whatIsGround);

   
    
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,
            transform.position.y - GroundBelow().distance));
        
    }
    
    
    public void HopAndGenerateShockwaves()
    {
        
        GenerateShockwave(Vector2.left);
        GenerateShockwave(Vector2.right);
        
    }
    
    public void GenerateShockwave(Vector2 _direction)
    {
        // Create a shockwave instance and set its speed and direction
        shockwavePrefab.SetActive(true);
        GameObject shockwave = Instantiate(shockwavePrefab, shockWaveSpawn.transform.position, Quaternion.identity);
        Rigidbody2D rbi = shockwave.GetComponent<Rigidbody2D>();
        if (rbi!=null)
        { 
            rbi.velocity = _direction * shockWaveSpeed;
        }
        Destroy(shockwave, shockwaveDuration);
    }

    
}
