using UnityEngine;

public enum EquipmentType
{
    Weapon,
    Armor,
    Amulet
}

[CreateAssetMenu(fileName = "New Name Data", menuName = "Data/Equipment")]
public class ItemData_Equipment : ItemData
{
    public EquipmentType equipmentType;
    
    [Header("Offensive stats")] public int damage;
    [Header("Defensive stats")] public int health;
    
    public void AddModifiers()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        playerStats.damage.AddModifier(damage);
        playerStats.maxHealth.AddModifier(health);
    }

    public void RemoveModifiers()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        playerStats.damage.RemoveModifier(damage);
        playerStats.maxHealth.RemoveModifier(health);
    }
}
