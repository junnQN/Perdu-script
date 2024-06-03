using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class  Inventory : MonoBehaviour,ISaveManager
{
    public static Inventory instance;
    
    public List<ItemData> startingItems;
    
    public List<InventoryItem> inventory;
    public Dictionary<ItemData, InventoryItem> inventoryDictionary;
    
    //public List<InventoryItem> equipment;
    //public Dictionary<ItemData_Equipment,InventoryItem> equipmentDictionary;
    
    //public List<InventoryItem> stash;
    //public Dictionary<ItemData, InventoryItem> stashDictionary;

    [Header("Inventory UI")] 
    //[SerializeField] private Transform inventorySlotParent;
    //[SerializeField] private Transform stashSlotParent;
    //[SerializeField] private Transform equipmentSlotParent;

    //private UI_ItemSlot[] inventoryItemSlot;
    //private UI_ItemSlot[] stashItemSlot;
    //private UI_EquipmentSlot[] equipmentSlot;

    [Header("Item cooldown")] 
    private float lastTimeUsedFlask;
    
    public float flaskCoolDown { get; private set; }

    [Header("Database")] 
    public List<ItemData> itemDatabase;
    public List<InventoryItem> loadedItems;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        inventory = new List<InventoryItem>();
        inventoryDictionary = new Dictionary<ItemData, InventoryItem>();

        /*stash = new List<InventoryItem>();
        stashDictionary = new Dictionary<ItemData, InventoryItem>();*/

        /*equipment = new List<InventoryItem>();
        equipmentDictionary = new Dictionary<ItemData_Equipment, InventoryItem>();*/

       //inventoryItemSlot = inventorySlotParent.GetComponentsInChildren<UI_ItemSlot>();
       //stashItemSlot = stashSlotParent.GetComponentsInChildren<UI_ItemSlot>();
       //equipmentSlot = equipmentSlotParent.GetComponentsInChildren<UI_EquipmentSlot>();

       AddStartingItems();
    }

    private void AddStartingItems()
    {
        if (loadedItems.Count > 0)
        {
            foreach (InventoryItem item in loadedItems)
            {
                for (int i = 0; i < item.stackSize; i++)
                {
                    AddItem(item.data);
                }
            }
            return;
        }
        
        for (int i = 0; i < startingItems.Count; i++)
        {
            AddItem(startingItems[i]);
        }
    }

    /*public void EquipItem(ItemData _item)
    {
        ItemData_Equipment newEquipment=_item as ItemData_Equipment;
        InventoryItem newItem = new InventoryItem(newEquipment);

        ItemData_Equipment oldEquipment = null;

        foreach (KeyValuePair<ItemData_Equipment,InventoryItem> item in equipmentDictionary )
        {
            if (item.Key.equipmentType == newEquipment.equipmentType)
                oldEquipment = item.Key;
        }

        if (oldEquipment != null)
        {
            UnequipItem(oldEquipment);
            AddItem(oldEquipment);
        }
        
        equipment.Add(newItem);
        equipmentDictionary.Add(newEquipment, newItem);
        newEquipment.AddModifiers();
        
        RemoveItem(_item);
        
        UpdateSlotUI();
    }*/

    /*public void UnequipItem(ItemData_Equipment itemToRemove)
    {
        if (equipmentDictionary.TryGetValue(itemToRemove, out InventoryItem value))
        {
            equipment.Remove(value);
            equipmentDictionary.Remove(itemToRemove);
            itemToRemove.RemoveModifiers();
        }
    }*/

    private void UpdateSlotUI()
    {
        /*for (int i = 0; i < equipmentSlot.Length; i++)
        {
            foreach (KeyValuePair<ItemData_Equipment,InventoryItem> item in equipmentDictionary )
            {
                if (item.Key.equipmentType == equipmentSlot[i].slotType)
                    equipmentSlot[i].UpdateSlot(item.Value);
            }
        }*/
        
        /*for (int i = 0; i < inventoryItemSlot.Length; i++)
        {
            inventoryItemSlot[i].CleanUpSlot();
        }*/
        
        /*for (int i = 0; i < stashItemSlot.Length; i++)
        {
            stashItemSlot[i].CleanUpSlot();
        }*/
        
        /*for (int i = 0; i < inventory.Count; i++)
        {
            inventoryItemSlot[i].UpdateSlot(inventory[i]);
        }*/

        /*
        for (int i = 0; i < stash.Count; i++)
        {
            stashItemSlot[i].UpdateSlot(stash[i]);
        }*/
    }

    public void AddItem(ItemData _item)
    {
        if (_item.itemType == ItemType.Equipment)
        {
            AddToInventory(_item);
        }
        /*else if (_item.itemType == ItemType.Material)
        {
            AddToStash(_item);
        }*/
        else if(_item.itemType==ItemType.Flask)
        {
            AddToInventory(_item);
        }
        else if (_item.itemType == ItemType.Gem)
        {
            AddToInventory(_item);
        }
        else if (_item.itemType == ItemType.Green)
        {
            AddToInventory(_item);
        }
        else if (_item.itemType == ItemType.Orange)
        {
            AddToInventory(_item);
        }
        UpdateSlotUI();
    }

    /*private void AddToStash(ItemData _item)
    {
        if (stashDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            stash.Add(newItem);
            stashDictionary.Add(_item, newItem);
        }
    }*/

    private void AddToInventory(ItemData _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            inventory.Add(newItem);
            inventoryDictionary.Add(_item, newItem);
        }
    }

    public void RemoveItem(ItemData _item)
    {
        if (inventoryDictionary.TryGetValue(_item, out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                inventory.Remove(value);
                inventoryDictionary.Remove(_item);
            }
            else
                value.RemoveStack();
        }

        /*if (stashDictionary.TryGetValue(_item, out InventoryItem stashValue))
        {
            if (stashValue.stackSize <= 1)
            {
                stash.Remove(stashValue);
                stashDictionary.Remove(_item);
            }
            else
            {
                stashValue.RemoveStack();
            }
        }*/
        
        UpdateSlotUI();
    }

    /*public List<InventoryItem> GetEquipmentList() => equipment;
    public List<InventoryItem> GetStashList() => stash;*/

    /*public ItemData_Equipment GetEquipment(EquipmentType _type)
    {
        ItemData_Equipment equippedItem = null;
        foreach (KeyValuePair<ItemData_Equipment,InventoryItem> item in equipmentDictionary )
        {
            if (item.Key.equipmentType == _type)
                equippedItem = item.Key;
        }

        return equippedItem;
    }*/
    
    public ItemData GetFlask(ItemType _type)
    {
        ItemData flaskItem = null;
        foreach (KeyValuePair<ItemData,InventoryItem> item in inventoryDictionary)
        {
            if (item.Key.itemType == _type)
                flaskItem = item.Key;
        }

        return flaskItem;
    }

    public void UseFlask()
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        ItemData currentFlask = GetFlask(ItemType.Flask);

        if (currentFlask == null)
            return;

        bool canUseFlask = Time.time > lastTimeUsedFlask + flaskCoolDown;

        if (canUseFlask && playerStats.currentHealth < 50)
        {
            flaskCoolDown = currentFlask.itemCooldown;
            currentFlask.Effect(null);
            RemoveItem(currentFlask);
            lastTimeUsedFlask = Time.time;
        }
        else
        {
            Debug.Log("Flask on cooldown");
        }
    }
    
    public bool CheckGem()
    {
        foreach (KeyValuePair<ItemData,InventoryItem> item in inventoryDictionary)
        {
            if (item.Key.itemType == ItemType.Gem)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool CheckGreenGem()
    {
        foreach (KeyValuePair<ItemData,InventoryItem> item in inventoryDictionary)
        {
            if (item.Key.itemType == ItemType.Green)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool CheckOrangeGem()
    {
        foreach (KeyValuePair<ItemData,InventoryItem> item in inventoryDictionary)
        {
            if (item.Key.itemType == ItemType.Orange)
            {
                return true;
            }
        }
        return false;
    }

    public int GetAmountFlask()
    {
        foreach (KeyValuePair<ItemData,InventoryItem> item in inventoryDictionary)
        {
            if (item.Key.itemType == ItemType.Flask)
            {
                return item.Value.stackSize;
            }
        }
        
        return 0;
    }


    public void LoadData(GameData _data)
    {
        foreach (KeyValuePair<string,int> pair in _data.inventory)
        {
            foreach (var item in itemDatabase)
            {
                if (item != null && item.itemId == pair.Key)
                {
                    InventoryItem itemToLoad = new InventoryItem(item);
                    itemToLoad.stackSize = pair.Value;
                    
                    loadedItems.Add(itemToLoad);
                }
            }
        }
    }

    public void SaveData(ref GameData _data)
    {
        _data.inventory.Clear();

        foreach (KeyValuePair<ItemData,InventoryItem> pair in inventoryDictionary)
        {
            _data.inventory.Add(pair.Key.itemId,pair.Value.stackSize);
        }
    }
#if UNITY_EDITOR
    [ContextMenu("Fill up item database")]
    private void FillUpItemDatabase() => itemDatabase = new List<ItemData>(GetItemDatabase());
    private List<ItemData> GetItemDatabase()
    {
        List<ItemData> itemDatabase = new List<ItemData>();
        string[] assetNames = AssetDatabase.FindAssets("",new[]{"Assets/Data/Equipment"});

        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(SOpath);
            itemDatabase.Add(itemData);
            
        }

        return itemDatabase;
    }
    
#endif
}
