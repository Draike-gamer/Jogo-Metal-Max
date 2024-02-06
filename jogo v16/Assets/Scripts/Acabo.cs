using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject inimigoEspecifico;
    public float tempoDeEspera = 3f; // Tempo de espera em segundos ap�s a destrui��o do inimigo espec�fico
    private bool inimigoDestruido = false;

    void Update()
    {
        // Verifica se o inimigo espec�fico foi destru�do
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

        // Coloque aqui o c�digo para passar para a pr�xima fase
        PassarParaProximaFase();
    }

    void PassarParaProximaFase()
    {
        // Coloque aqui o c�digo para passar para a pr�xima fase
        SceneManager.LoadScene("Final");
    }
}
