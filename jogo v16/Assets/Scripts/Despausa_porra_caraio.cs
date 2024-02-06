using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController1 : MonoBehaviour
{
    void Start()
    {
        // Inscreva-se para o evento de in�cio de fase
        PhaseManager.OnPhaseStart += HandlePhaseStart;

        // Despausar o jogo automaticamente no in�cio
        UnpauseGame();
    }

    void OnDestroy()
    {
        // Certifique-se de cancelar a inscri��o do evento ao destruir este objeto
        PhaseManager.OnPhaseStart -= HandlePhaseStart;
    }

    void HandlePhaseStart()
    {
        // N�o � necess�rio fazer nada aqui, pois o jogo j� est� despausado
    }

    void UnpauseGame()
    {
        Time.timeScale = 1f; // Defina o timescale para 1 para despausar o jogo
    }
}

// Classe que gerencia o in�cio das fases
public static class PhaseManager
{
    // Evento acionado quando uma nova fase come�a
    public static event System.Action OnPhaseStart;

    // M�todo para chamar quando uma nova fase come�a
    public static void StartPhase()
    {
        if (OnPhaseStart != null)
        {
            OnPhaseStart(); // Dispara o evento
        }
    }
}