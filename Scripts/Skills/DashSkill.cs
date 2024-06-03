using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    public Inventory inventory { get; private set; }
    private Skill skill;
    
    [Header("Dash")] 
    public bool dashUnlocked;

    [Header("Clone on dash")] 
    public bool cloneOnDashUnlocked;
    
    [Header("Clone on arrival")] 
    public bool cloneOnArrivalUnlocked;
    
    private void Start()
    {
        inventory = Inventory.instance;
    }

    protected override void Update()
    {
        base.Update();
        
        UnlockDash();
    }

    public override void UseSkill()
    {
        base.UseSkill();
        
    }

    public void UnlockDash()
    {
        if (inventory.CheckGem())
        {
            dashUnlocked = true;
        }

        if (CheckDead())
        {
            dashUnlocked = false;
        }
        
    }

    protected override bool CheckDead()
    {
        return base.CheckDead();
    }
    
}
