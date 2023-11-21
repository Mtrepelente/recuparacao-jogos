using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Inimigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public int TipoInimigo;
    public float VelocidadeInimigo;
    public float VelocidadePerserguir;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (TipoInimigo == 1)
        {
            StartCoroutine(mudarDirecao());

        }
        else
        {
            player = Player.instance.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TipoInimigo == 1)
        {
            rb.velocity = new Vector2(VelocidadeInimigo, rb.velocity.y);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, VelocidadePerserguir);
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            }  
         
        
    }
    public IEnumerator mudarDirecao()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(mudarDirecao());
        VelocidadeInimigo *= -1;
        if (VelocidadeInimigo > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TiroPlayer")) 
        {
         Destroy(collision.gameObject);
         Destroy(gameObject);
        
        }
    }
}
