using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour
{
    public static EnterShop instance;
    public GameObject label;
    public bool inShop;
    
    private void Awake()
    {
        if(instance!=null)
            Destroy(instance.gameObject);
        else 
            instance = this;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            inShop = true;
            label.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            inShop = false;
            label.SetActive(false);
        }
    }

    public void ActiveLabel()
    {
        label.SetActive(true);
    }
    
}
