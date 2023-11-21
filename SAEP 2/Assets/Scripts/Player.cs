using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    // Start is called before the first frame update
    public string nome = "andre";
    public int x = 11;
    public float sesi = 1.1f;
    public bool y = true;
    public Rigidbody2D mybody;
    public float input = 0f;
    public float velocidade = 0f;
    public float jumpforce = 0f;
    public bool onground = true;
    public float inputjump = 0f;
    public int numeroDeMoedas;
    public TMP_Text textoDeMoedas;
    public GameObject mira;
    public GameObject tiroPlayer;
    public float inputTiro;
    public bool podeAtirar = true;
    public string animacaoAtual;
    public Animator myanim;
    private void Awake()
    {
        instance= this;
    }
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
        mybody.velocity = new Vector2(input * velocidade, mybody.velocity.y);
        if (onground == true && inputjump != 0) 
        {
            onground = false;
            mybody.AddForce(new Vector2(mybody.velocity.x, jumpforce));
        }
        if (input > 0) 
        {
            transform.localScale = new Vector3(1,1,1);
        }
        if (input < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inputTiro != 0 && podeAtirar == true) 
        {
            StartCoroutine(Reload());
            GameObject instancia = Instantiate(tiroPlayer, mira.transform.position, Quaternion.identity);
            if (transform.localScale.x == 1)
            {
                instancia.GetComponent<TiroPlayer>().velocidadeBala = 10;
            }
            else 
            {
                instancia.GetComponent<TiroPlayer>().velocidadeBala = -10;
            }
        }
        Animations();
    }
    void mudarAnimacao(string animacao)
    {
        if (animacaoAtual == animacao)
        {
            return;
        }
        myanim.Play(animacao);
    }
    void Animations()
    {
        if (inputTiro != 0 && podeAtirar == false)
        {
            mudarAnimacao("Shot");
        }
        else
        {

            if (mybody.velocity.x == 0 && onground)
            {
                mudarAnimacao("Idle");
            }
            if (mybody.velocity.x != 0 && onground)
            {
                mudarAnimacao("Run");
            }
            if (mybody.velocity.y > 0 && !onground)
            {
                mudarAnimacao("Jump");
            }
            if (mybody.velocity.y < 0 && !onground)
            {
                mudarAnimacao("Fall");
            }

        }
    }
    public IEnumerator Reload()
    {
        podeAtirar = false;
        yield return new WaitForSeconds(0.5f);
        podeAtirar = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Joia"))
        {
            numeroDeMoedas++;
            textoDeMoedas.text = "Joias: "+ numeroDeMoedas;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
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
