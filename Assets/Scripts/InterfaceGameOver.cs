using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour
{
    [SerializeField]
    public GameObject fundoGameOver;
    [SerializeField]
    private Text valorRecorde;
    private Pontuacao pontuacao;
    private int recorde;
    [SerializeField]
    private Image posicaoMedalha;
    [SerializeField]
    private Sprite medalhaOuro, medalhaPrata, medalhaBronze;

    private void Start()
    {
        pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }

    public void MostrarInterface()
    {
        AtualizarInterfaceGrafica();
        fundoGameOver.SetActive(true);
    }

    public void EsconderInterface()
    {
        fundoGameOver.SetActive(false);
    }

    private void AtualizarInterfaceGrafica()
    {
        recorde = PlayerPrefs.GetInt(Tags.Recorde);
        valorRecorde.text = recorde.ToString();
        VerificarCorMedalha();
    }

    private void VerificarCorMedalha()
    {
        if(pontuacao.Pontos > recorde - 2)
        {
            posicaoMedalha.sprite = medalhaOuro;
        }
        else if(pontuacao.Pontos > recorde / 2)
        {
            posicaoMedalha.sprite = medalhaPrata;
        }
        else
        {
            posicaoMedalha.sprite = medalhaBronze;
        }
    }
}
