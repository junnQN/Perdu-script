
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public enum ItemType
{
    Material,
    Equipment,
    Flask,
    Gem,
    Green,
    Orange
}

[CreateAssetMenu(fileName = "New Name Data", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public Sprite icon;
    public string itemId;

    [Range(0,100)]
    public float dropChance;
    
    public Item_Effect[] itemEffects;
    public float itemCooldown;
    
    public void Effect(Transform _enemyPos)
    {
        foreach (var item in itemEffects)
        {
            item.ExecuteEffect(_enemyPos);
        }
    }

    private void OnValidate()
    {
        #if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        itemId = AssetDatabase.AssetPathToGUID(path);
        #endif
    }
}
