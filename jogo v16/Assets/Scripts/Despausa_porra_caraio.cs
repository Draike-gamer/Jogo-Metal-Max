using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController1 : MonoBehaviour
{
    void Start()
    {
        // Inscreva-se para o evento de início de fase
        PhaseManager.OnPhaseStart += HandlePhaseStart;

        // Despausar o jogo automaticamente no início
        UnpauseGame();
    }

    void OnDestroy()
    {
        // Certifique-se de cancelar a inscrição do evento ao destruir este objeto
        PhaseManager.OnPhaseStart -= HandlePhaseStart;
    }

    void HandlePhaseStart()
    {
        // Não é necessário fazer nada aqui, pois o jogo já está despausado
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f; // Defina o timescale para 1 para despausar o jogo
    }
}

// Classe que gerencia o início das fases
public static class PhaseManager
{
    // Evento acionado quando uma nova fase começa
    public static event System.Action OnPhaseStart;

    // Método para chamar quando uma nova fase começa
    public static void StartPhase()
    {
        if (OnPhaseStart != null)
        {
            OnPhaseStart(); // Dispara o evento
        }
    }
}