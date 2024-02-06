using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    public PauseGameController pauseGameController;

    void Start()
    {
        // Encontre o GameController na cena
        pauseGameController = GameObject.FindObjectOfType<PauseGameController>();

        // Adicione uma função de clique ao botão
        GetComponent<Button>().onClick.AddListener(ResumeGame);
    }

    void ResumeGame()
    {
        // Chame a função de retomar jogo no GameController
        pauseGameController.ResumeGame();
    }
}

