using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControleJogo : MonoBehaviour
{
    public Text textoParaAlterar;
    private string[] textos = {
        "Após a humanidade atingir um nível de evolução que possibilitou a criação de máquinas autoconscientes, a esperança se dissipou quando elas assumiram o controle do ódio humano. Uma onda de destruição varreu tudo o que a humanidade havia construído, restando apenas destruição.",
        "Nesse cenário desolador, emerge a figura de um jovem viajante cuja jornada é marcada por uma busca incansável por seus pais perdidos. Rex, um ser fruto de experimentos, foi desenvolvido como uma arma, mas, ele se recusa a exercer a função para a qual foi criado, assim procurando proteger os mais fracos.",
        "Enquanto Rex atravessa um mundo despedaçado, onde a destruição das máquinas é palpável e a desesperança paira no ar, sua busca por seus pais se entrelaça com atos heroicos, tornando-o uma figura inspiradora para os poucos assentamentos humanos remanescentes. Em meio ao caos, Rex representava a resistência, uma esperança viva que desafia as sombras do apocalipse."
    };
    private int indiceAtual = 0;
    private int contagemPressionamento = 0;

    void Start()
    {
        // Inicialize o texto
        AtualizarTexto();
    }

    public void OnButtonClick()
    {
        // Chamado quando o botão é pressionado
        contagemPressionamento++;

        if (contagemPressionamento < 3) // Alterado para 3 para contemplar os 3 textos
        {
            // Altera o texto três vezes
            indiceAtual = (indiceAtual + 1) % textos.Length;
            AtualizarTexto();
        }
        else
        {
            // Passa para a próxima fase (implemente a lógica da próxima fase aqui)
            PassarParaProximaFase();
        }
    }

    private void AtualizarTexto()
    {
        // Atualiza o texto do objeto de texto
        textoParaAlterar.text = textos[indiceAtual];
    }

    private void PassarParaProximaFase()
    {
        // Implemente a lógica para passar para a próxima fase aqui
        SceneManager.LoadScene("tutorial");
    }
}