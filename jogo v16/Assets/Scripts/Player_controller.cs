using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [SerializeField]
    public float acceleration = 5f;  // Aceleração do jogador
    public float deceleration = 10f; // Desaceleração do jogador
    public float speed = 5f;
    public float dashSpeed = 10f; // Velocidade do dash
    public float dashDuration = 0.2f; // Duração do dash
    public Rigidbody2D playerRb;
    public Animator animator;
    public Collider2D portaCollider;
    public AudioClip audioClip;
    public AudioClip audioClipPasso;

    private bool isDashing = false;
    private Vector2 dashDirection;

    Vector2 movimento;

    // Update is called once per frame
    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movimento.x);
        animator.SetFloat("vertical", movimento.y);
        animator.SetFloat("velocidade", movimento.sqrMagnitude);

        if (movimento != Vector2.zero)
        {
            animator.SetFloat("horizontalidade", movimento.x);
            animator.SetFloat("verticalidade", movimento.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            // Iniciar o dash
            StartCoroutine(PerformDash());
        }
    }

    IEnumerator PerformDash()
    {
        isDashing = true;
        
        // Define a direção do dash com base na posição do mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dashDirection = (mousePosition - transform.position).normalized;

        // Aplica a velocidade do dash durante a duração do dash
        playerRb.velocity = dashDirection * dashSpeed;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            // Calcular a velocidade atual do jogador
            Vector2 currentVelocity = playerRb.velocity;

            // Calcular a aceleração com base na entrada do jogador
            Vector2 targetVelocity = movimento.normalized * speed;

            Vector2 accelerationVector = (targetVelocity - currentVelocity) * acceleration;

            // Aplicar aceleração
            playerRb.AddForce(accelerationVector);

            // Aplicar desaceleração
            if (movimento == Vector2.zero)
            {
                Vector2 decelerationVector = -currentVelocity * deceleration;
                playerRb.AddForce(decelerationVector);
            }

            // Limitar a velocidade máxima
            if (playerRb.velocity.magnitude > speed)
            {
                playerRb.velocity = playerRb.velocity.normalized * speed;
                PlayAudioAnda();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chave"))
        {
            // Destrua a chave
            Destroy(collision.gameObject);
            PlayAudio();

            // Ative o componente da porta
            if (portaCollider != null)
            {
                portaCollider.enabled = true;
            }
        }
    }

    void PlayAudio()
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        }
        else
        {
            Debug.LogWarning("Nenhum áudio atribuído ao script.");
        }
    }

    void PlayAudioAnda()
    {
        if (audioClipPasso != null)
        {
            AudioSource.PlayClipAtPoint(audioClipPasso, Camera.main.transform.position);
        }
        else
        {
            Debug.LogWarning("Nenhum áudio de passo atribuído ao script.");
        }
    }
}