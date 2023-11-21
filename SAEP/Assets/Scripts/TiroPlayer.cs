using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float VelocidadedaBala;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(VelocidadedaBala, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")  || collision.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
    }
}
