using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{

    public Rigidbody2D corpoInimigo;
    public float velocidade;
    public float tempoParaVirar;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MudarDirecao");
    }

    // Update is called once per frame
    void Update()
    {
        corpoInimigo.velocity = new Vector2(velocidade, 0);
    }

    public IEnumerator MudarDirecao()
    {
        velocidade *= -1;
        yield return new WaitForSeconds(tempoParaVirar);
        StartCoroutine("MudarDirecao");
    }

}
