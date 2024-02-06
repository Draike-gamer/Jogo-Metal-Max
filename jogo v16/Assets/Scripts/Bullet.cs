using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] private int damage = 5;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Inimigo"))
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            Destroy(this.gameObject);
            PlayAudio();

        }
        if (collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
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
}
