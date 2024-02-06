using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Scene_Manager : MonoBehaviour
{
    private coracaum_player vida;
    public GameObject telaDeMorte;

    // Start is called before the first frame update
    void Start()
    {
        vida = FindObjectOfType<coracaum_player>(); // Ajustei para FindObjectOfType ao invés de FindAnyObjectByType
        telaDeMorte.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        VerificarEstadoDaVida();
    }

    void VerificarEstadoDaVida()
    {
        if (vida.vida <= 0)
        {
            AtivarTelaDeMorte();
        }
    }

    void AtivarTelaDeMorte()
    {
        telaDeMorte.SetActive(true);
        // Aqui você pode adicionar qualquer outra lógica relacionada à tela de morte, como pausar o jogo ou desativar controles
    }

    void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}