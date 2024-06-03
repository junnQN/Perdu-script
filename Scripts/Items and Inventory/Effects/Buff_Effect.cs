using UnityEngine;

public enum StatType
{
    damage,
    health
}

[CreateAssetMenu(fileName = "Buff effect", menuName = "Data/Item effect/Buff effect")]

public class Buff_Effect : Item_Effect
{
    private PlayerStats stats;
    [SerializeField] private StatType buffType;
    [Range(0, 100)] 
    [SerializeField] private int buffPercent;
    
    public override void ExecuteEffect(Transform _enemyPos)
    {
        stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        
        stats.IncreaseStatBy(StatIndex()*(buffPercent/100) ,StatToModify());
    }

    private Stat StatToModify()
    {
        if (buffType == StatType.damage)
            return stats.damage;
        else if (buffType == StatType.health)
            return stats.maxHealth;

        return null;
    }

    private int StatIndex()
    {
        if (buffType == StatType.damage)
            return stats.damage.GetValue();
        else if (buffType == StatType.health)
            return stats.maxHealth.GetValue();

        return 0;
    }
}
