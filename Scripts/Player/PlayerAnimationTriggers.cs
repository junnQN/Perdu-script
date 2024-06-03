using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }

    private void AttackTrigger()
    {
        AudioManager.instance.PlaySFX(2, null);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);
        
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                EnemyStats _target = hit.GetComponent<EnemyStats>();
                player.stats.DoDamage(_target);
                
                //Inventory.instance.GetEquipment(EquipmentType.Weapon).Effect(_target.transform);
            }

            if (hit.GetComponent<DummyStat>() != null)
            {
                DummyStat _target = hit.GetComponent<DummyStat>();
                player.stats.DoDamage(_target);
            }
        }
    }
}
