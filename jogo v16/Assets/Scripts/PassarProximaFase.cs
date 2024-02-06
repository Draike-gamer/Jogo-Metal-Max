using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoFase : MonoBehaviour
{
    public float tempoParaTransicao = 10f; // Tempo em segundos para a transição
    public string nomeFaseAtual = "Historinha"; // Nome da cena da fase de histórinha
    public string nomeProximaFase = "Tutorial"; // Nome da cena da fase de tutorial

    private void Start()
    {
        // Inicia a contagem do tempo para a transição
        Invoke("IniciarTransicao", tempoParaTransicao);
    }

    private void IniciarTransicao()
    {
        // Verifica se a cena atual é a fase de histórinha
        if (SceneManager.GetActiveScene().name == nomeFaseAtual)
        {
            // Carrega a cena de tutorial após o tempo especificado
            SceneManager.LoadScene(nomeProximaFase);
        }
        else
        {
            Debug.LogWarning("Este script foi colocado em uma cena que não é a fase de histórinha.");
        }
    }
}