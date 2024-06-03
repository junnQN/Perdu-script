using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelMove : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        StartCoroutine(LabelUpDown());
    }

    private IEnumerator LabelUpDown()
    {
        rb.velocity = new Vector2(0, 5f * Time.deltaTime);
        
        if (rb.velocity.y == 0)
            rb.velocity = new Vector2(0, -5f);
        yield return new WaitForSeconds(0f);
    }

}
