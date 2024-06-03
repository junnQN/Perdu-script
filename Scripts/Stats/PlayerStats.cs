using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;

    [SerializeField] private int lastComboDmg;
    
    
    
    protected override void Start()
    {
        base.Start();

        player = GetComponent<Player>();
    }

    protected override void DecreaseHealthBy(int _damage)
    {
        base.DecreaseHealthBy(_damage);

        if (_damage > GetMaxHealthValue() * .3f)
        {
            player.SetupKnockbackPower(new Vector2(10,6));

            int randomSound = Random.Range(34, 35);
            AudioManager.instance.PlaySFX(randomSound,null);
        }
    }

    public override void DoDamage(CharacterStats _targetStats)
    {
        
        base.DoDamage(_targetStats);

        if (player.primaryAttack.comboCounter == 1 )
            damage.AddModifier(20);
        else  
            damage.RemoveModifier(20);
        
    }

    public override void TakeDamage(int _damage)
    {
        base.TakeDamage(_damage);
        
        player.DamageEffect();
    }
    
    protected override void Die()
    {
        base.Die();
        
        player.Die();
        
        //GetComponent<PlayerItemDrop>()?.GenerateDrop();
    }
    
    
}