using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string nome = "mateus";
    public int x = 11;
    public float sesi = 1.1f;
    public bool y = true;
    public Rigidbody2D mybody;
    public float input = 0f;
    public float velocity = 0f;
    public float jumpforce = 0f;
    public bool onground = true;
    public float inputjump = 0f;
    public int numeroDeMoedas;
    public TMP_Text textoDeMoedas;
    public GameObject mira;
    public GameObject tiroPlayer;
    public float inputTiro;




    void Start()
    {
        x = 50;
        if (x == 50)
        {
            nome = "luva de pedreiro";
        }
        else
        {
            nome = "cr7 junior";
        }
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");
        inputjump = Input.GetAxisRaw("Jump");
        inputTiro = Input.GetAxisRaw("Fire1");
        mybody.velocity = new Vector2(input * velocity, mybody.velocity.y);
        if (onground == true && inputjump != 0)
        {
            onground = false;
            mybody.AddForce(new Vector2(mybody.velocity.x, jumpforce));
        }
        if (input > 0)
        {
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (input < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (inputTiro != 0)
            {
                GameObject instancia = Instantiate(tiroPlayer, mira.transform.position, Quaternion.identity);
                if (transform.localScale.x==1)
                {
                    instancia.GetComponent<TiroPlayer>().VelocidadedaBala = 10;

                }
                else
                {
                    instancia.GetComponent<TiroPlayer>().VelocidadedaBala = -10;
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Joia"))
        {
            numeroDeMoedas++;
            textoDeMoedas.text = "Joias: " + numeroDeMoedas;
            Destroy(collision.gameObject);


        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
        {
            onground = true;

        }     
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onground = false;

        }
    }

}

