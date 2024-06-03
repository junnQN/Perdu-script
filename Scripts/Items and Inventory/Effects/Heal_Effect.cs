using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal effect", menuName = "Data/Item effect/Heal effect")]
public class Heal_Effect : Item_Effect
{
    [Range(0f, 1f)] 
    [SerializeField] private float healPercent;

    public override void ExecuteEffect(Transform _enemyPos)
    {
        
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        
        int healAmount = Mathf.RoundToInt(playerStats.GetMaxHealthValue() * healPercent);

        playerStats.IncreaseHealthBy(healAmount);
    }
}
