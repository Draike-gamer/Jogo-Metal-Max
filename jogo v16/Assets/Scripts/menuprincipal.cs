using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuprincipal : MonoBehaviour
{
    [SerializeField] private string historinha;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    public void Jogar()
    {
      SceneManager.LoadScene("historinha");
    }

    public void AbrirOpcoes()
    {
    painelMenuInicial.SetActive(false);
    painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
    painelOpcoes.SetActive(false);
    painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
    Application.Quit();
    }
}
