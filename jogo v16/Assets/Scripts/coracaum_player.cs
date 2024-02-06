using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class coracaum_player : MonoBehaviour
{
    public int vida;
    public int vidaMax;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vasio;
    public AudioClip audioClip;

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        Morrrreu();
    }

    void HealthLogic()
    {
        if (vida > vidaMax)
        {
            vida = vidaMax;
        }
        for (int i = 0; i < coracao.Length; i++)
        {
            if (i < vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vasio;
            }
            if (i < vidaMax)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }

    void Morrrreu()
    {
        if (vida <= 0)
        {
            GetComponent<Player_controller>().enabled = false;
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