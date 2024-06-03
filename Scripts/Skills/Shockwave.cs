using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player>() != null)
            {
                PlayerStats target = other.GetComponent<PlayerStats>();
                target.TakeDamage(damageAmount);
            }
            Destroy(gameObject);
        }
    }
}
