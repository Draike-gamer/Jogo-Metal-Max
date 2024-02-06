using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoProximaFase : MonoBehaviour
{
    public float tempoParaProximaFase = 5f; // Tempo em segundos para a transição
    public string nomeProximaFase = "NomeDaProximaFase"; // Substitua pelo nome real da próxima fase

    private void Start()
    {
        // Inicia a contagem do tempo para a próxima fase
        Invoke("CarregarProximaFase", tempoParaProximaFase);
    }

    private void CarregarProximaFase()
    {
        // Carrega a próxima fase
        SceneManager.LoadScene(nomeProximaFase);
    }
}
