using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public AudioClip audioClip;
    public coracaum_player coracao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            coracao.vida--;
            PlayAudio();
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
}
