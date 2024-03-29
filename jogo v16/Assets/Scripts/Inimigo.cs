using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
  
  [SerializeField]
  private Transform alvo;

  [SerializeField]
  private float velocidadeMovimento;
  
  [SerializeField]
  private float distanciaMinima;

  [SerializeField]
  private Rigidbody2D rigidbody;

  [SerializeField]
  private SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;

       float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);
       if (distancia >= this.distanciaMinima) {
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;

        Debug.Log("Direcao:" + direcao);
        
        this.rigidbody.velocity = (this.velocidadeMovimento * direcao);
        
        if (this.rigidbody.velocity.x > 0){ //Direita
            this.spriteRenderer.flipX = false;
        } else if (this.rigidbody.velocity.x < 0){ //Esquerda
            this.spriteRenderer.flipX = true;
        }
    }else {
      //parar a movimentacao
      this.rigidbody.velocity = Vector2.zero;
    }
    }
        /*/private void OnCollisionEnter2D(Collision2D collision)
        {
            // Verifica se a colisao e com um objeto que tenha a tag "Bala"
            if (collision.gameObject.CompareTag("Bala"))
            {
                // Destrua o inimigo
                Destroy(this.gameObject);
            }
        } /*/
    }
