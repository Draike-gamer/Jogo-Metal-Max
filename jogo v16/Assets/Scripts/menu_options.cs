using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject optionsMenuPanel;
    public Slider volumeSlider;
    public Button backButton; // Referência para o botão no inspetor
    public AudioListener audioListener; // Campo para referenciar o AudioListener

    void Start()
    {
        // Define o valor inicial do slider para o volume atual
        volumeSlider.value = AudioListener.volume;

        // Adiciona um listener de clique ao botão
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    // Chamado quando o valor do slider é alterado
    public void OnVolumeChanged()
    {
        SetGlobalVolume(volumeSlider.value);
    }

    // Método para definir o volume globalmente
    private void SetGlobalVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    // Método chamado quando o botão "Back" é clicado
    public void GoBackToPauseMenu()
    {
        // Desativa o painel de opções
        optionsMenuPanel.SetActive(false);
        // Ativa o painel de pausa
        pauseMenuPanel.SetActive(true);
    }

    // Método chamado quando o botão "Back" é clicado
    void OnBackButtonClick()
    {
        GoBackToPauseMenu();
    }
}
