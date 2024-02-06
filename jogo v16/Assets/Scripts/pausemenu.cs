using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameController : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject optionsPanel; // Referência para o painel de opções
    public GameObject player;

    void Update()
    {
        // Verifique se a tecla "Esc" foi pressionada para pausar/despausar o jogo
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else if (!optionsPanel.activeSelf) // Verifica se o painel de opções não está ativo
                PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pausa o tempo no jogo
        isPaused = true;
        pauseMenu.SetActive(true); // Ativa o menu de pausa
        player.SetActive(false); // Desativa o jogador
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Retoma o tempo no jogo
        isPaused = false;
        pauseMenu.SetActive(false);   // Desativa o menu de pausa
        player.SetActive(true); // Ativa o jogador
    }

    // Função para abrir o painel de opções
    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true); // Ativa o painel de opções
        pauseMenu.SetActive(false); // Desativa o menu de pausa quando as opções são abertas
    }

    // Função para fechar o painel de opções (pode ser chamada de um botão no próprio painel de opções)
    public void CloseOptionsPanel()
    {
        optionsPanel.SetActive(false); // Desativa o painel de opções
        pauseMenu.SetActive(true); // Ativa o menu de pausa quando as opções são fechadas
    }

    // Adicione mais funcionalidades aqui, se necessário

    public void QuitGame()
    {
        // Adicione funcionalidades para sair do jogo (pode ser necessário ajustar isso dependendo do seu build settings)
        Application.Quit();
    }
}
