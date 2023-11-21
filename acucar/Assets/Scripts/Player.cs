using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


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

    //Coletar
    public int coletados;

    //Game Over
    public GameObject painelGameOver;
    public TMP_Text textoColetados;


    // Start is called before the first frame update
    void Start()
    {
        coletados = 0;
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
        if (collision.CompareTag("Coletavel"))
        {
            coletados++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Inimigo"))
        {
            Destroy(collision.gameObject);
            painelGameOver.SetActive(true);
            textoColetados.text = "Pontuação: " + coletados;
            gameObject.SetActive(false);
        }
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(checkPosicao.transform.position, checkRaio);
    }

}
