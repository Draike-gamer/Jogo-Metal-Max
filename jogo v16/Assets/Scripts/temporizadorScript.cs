using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    public float tempoInicial = 60f; // Tempo inicial em segundos
    private float tempoRestante;
    public GameObject objetoTextoTemporizador; // Objeto do texto temporizador

    public GameObject telaDeMorte;

    private Text textoTemporizador; // Referência ao componente Text

    // Use this for initialization
    void Start()
    {
        tempoRestante = tempoInicial;

        // Verifica se o objeto do texto temporizador foi atribuído
        if (objetoTextoTemporizador != null)
        {
            textoTemporizador = objetoTextoTemporizador.GetComponent<Text>(); // Obtém o componente Text
            if (textoTemporizador == null)
            {
                Debug.LogError("O objeto do texto temporizador não contém um componente Text.");
            }
        }
        else
        {
            Debug.LogError("O objeto do texto temporizador não foi atribuído.");
        }

        AtualizarTextoTemporizador();
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
            AtualizarTextoTemporizador();
        }
        else
        {
            // Tempo esgotado, ativa a tela de morte
            AtivarTelaDeMorte();
        }
    }

    void AtualizarTextoTemporizador()
    {
        if (textoTemporizador != null)
        {
            int minutos = Mathf.FloorToInt(tempoRestante / 60);
            int segundos = Mathf.FloorToInt(tempoRestante % 60);

            textoTemporizador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    void AtivarTelaDeMorte()
    {
        telaDeMorte.SetActive(true);
    }
}