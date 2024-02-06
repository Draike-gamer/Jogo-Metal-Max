using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject inimigoEspecifico;
    public float tempoDeEspera = 3f; // Tempo de espera em segundos após a destruição do inimigo específico
    private bool inimigoDestruido = false;

    void Update()
    {
        // Verifica se o inimigo específico foi destruído
        if (inimigoEspecifico == null && !inimigoDestruido)
        {
            // Inicia a contagem regressiva
            StartCoroutine(EsperarTempoDeEspera());
            inimigoDestruido = true;
        }
    }

    IEnumerator EsperarTempoDeEspera()
    {
        // Aguarda o tempo de espera
        yield return new WaitForSeconds(tempoDeEspera);

        // Coloque aqui o código para passar para a próxima fase
        PassarParaProximaFase();
    }

    void PassarParaProximaFase()
    {
        // Coloque aqui o código para passar para a próxima fase
        SceneManager.LoadScene("Final");
    }
}
