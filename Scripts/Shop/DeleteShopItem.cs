using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteShopItem : MonoBehaviour
{
    [SerializeField]private Button btnItem;
    
    void Start()
    {
        btnItem = GetComponentInChildren<Button>();
        btnItem.onClick.AddListener(DeleteItem);
    }

    void DeleteItem()
    {
        Destroy(this.gameObject);
    }
}
