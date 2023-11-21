using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D meuCorpo;
    public float velocidade;
    public float direcao;

    //Pulo
    public float inputPulo;
    public float forcaPulo;
    public LayerMask layerChao;
    public float checkRaio;
    public bool noChao;
    public GameObject checkPosicao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direcao = Input.GetAxis("Horizontal");
        inputPulo = Input.GetAxis("Jump");
        
        noChao = Physics2D.OverlapCircle(checkPosicao.transform.position, checkRaio, layerChao);

        meuCorpo.velocity = new Vector2(direcao * velocidade, meuCorpo.velocity.y);

        if(inputPulo != 0 && noChao == true)
        {
            meuCorpo.velocity = new Vector2(meuCorpo.velocity.x, forcaPulo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("coletario"))
        {
            coletarios++;S
            Destroy(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(checkPosicao.transform.position, checkRaio);
    }
}
