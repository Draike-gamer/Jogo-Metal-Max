using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    public string nomeDaProximaFase = "ProximaFase"; // Nome da próxima cena/fase

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            // Verifica se o objeto que colidiu é o jogador
            PassarParaProximaFase();
        }
    }

    void PassarParaProximaFase()
    {
        // Carrega a próxima cena/fase
        SceneManager.LoadScene(nomeDaProximaFase);
    }
}

