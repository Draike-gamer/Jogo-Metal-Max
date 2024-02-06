using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject TeladeMorte;
    public Button restartButton;
    public GameObject objetoParaDesativar;
    public GameObject player;

    private bool hasDiedAndPaused = false; // Variável para rastrear se o jogador morreu e o jogo foi pausado

    private void Start()
    {
        // Desativa o painel de morte e adiciona um listener ao botão de reinício
        TeladeMorte.SetActive(false);
        restartButton.onClick.AddListener(RestartLevel);
    }

    private void Update()
    {
        // Verifica se o jogador está morto e o jogo não foi pausado anteriormente
        if (PlayerIsDead() && !hasDiedAndPaused)
        {
            PauseGame(); // Pausa o jogo
            hasDiedAndPaused = true; // Marca que o jogador morreu e o jogo foi pausado
        }
    }

    private bool PlayerIsDead()
    {
        // Verifica se o painel de morte está ativo na cena
        return TeladeMorte.activeSelf;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; // Pausa o jogo
        player.SetActive(false); // Desativa o jogador
        objetoParaDesativar.SetActive(false); // Desativa o objeto na tela
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Despausa o jogo
        hasDiedAndPaused = false; // Reseta a variável de controle
        TeladeMorte.SetActive(false); // Desativa o painel de morte
    }

    public void RestartLevel()
    {
        // Reinicia a cena
        TeladeMorte.SetActive(false);
        Time.timeScale = 1f; // Garante que o jogo esteja despausado
        hasDiedAndPaused = false; // Reseta a variável de controle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}