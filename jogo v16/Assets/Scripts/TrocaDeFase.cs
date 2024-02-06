using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrocaDeFase : MonoBehaviour
{
    public GameObject[] objetosParaDesativar;
    public GameObject[] objetosParaAtivar;
    public int numeroDeApertar = 3;
    private int contagemDeApertar = 0;

    public Button botaoTrocaDeFase;

    private void Start()
    {
        // Desativa todos os objetos a serem ativados no início do jogo
        foreach (GameObject obj in objetosParaAtivar)
        {
            obj.SetActive(false);
        }

        // Adiciona um listener ao botão para responder ao clique
        botaoTrocaDeFase.onClick.AddListener(TrocarFase);
    }

    private void TrocarFase()
    {
        // Incrementa a contagem
        contagemDeApertar++;

        // Desativa os objetos e ativa outros
        AtualizarObjetos();

        // Verifica se é a terceira vez que o botão foi pressionado
        if (contagemDeApertar == numeroDeApertar)
        {
            // Muda de fase especificando a fase
            MudaDeFase("fase_1");
        }
    }

    private void AtualizarObjetos()
    {
        // Desativa os objetos a serem desativados
        foreach (GameObject obj in objetosParaDesativar)
        {
            obj.SetActive(false);
        }

        // Ativa os objetos a serem ativados
        foreach (GameObject obj in objetosParaAtivar)
        {
            obj.SetActive(true);
        }
    }

    private void MudaDeFase(string nomeDaFase)
    {
        // Aqui você pode adicionar código para mudar de fase
        Debug.Log("Mudando para a fase: " + nomeDaFase);
        SceneManager.LoadScene("transição_1");
    }
}