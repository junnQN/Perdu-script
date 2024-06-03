using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSkill : Skill
{
    public Inventory inventory { get; private set; }
    public bool healUnlock;

    private void Start()
    {
        inventory = Inventory.instance;
    }

    protected override void Update()
    {
        base.Update();
        
        UnlockHeal();
    }

    public void UnlockHeal()
    {
        if (inventory.CheckGreenGem())
            healUnlock = true;

        if (CheckDead())
        {
            healUnlock = false;
        }
    }
}
