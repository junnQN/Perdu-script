using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlaskAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private GameObject cooldownImage;
    
    private void Update()
    {
        Inventory inventory=Inventory.instance;
        itemText.text = inventory.GetAmountFlask().ToString();
        if (inventory.GetAmountFlask() == 0)
        {
            cooldownImage.SetActive(false);
        }
        else
        {
            cooldownImage.SetActive(true);
        }
    }
}
