using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    [SerializeField]
    public GameObject fundoGameOver;
    private ControlaAviao controlaAviao;
    private Pontuacao pontuacao;

    private void Start()
    {
        this.controlaAviao = GameObject.FindObjectOfType<ControlaAviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
    }
    public void FinalizarJogo()
    {
        Time.timeScale = 0f;
        this.fundoGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        this.fundoGameOver.SetActive(false);
        Time.timeScale = 1f;
        this.controlaAviao.Reiniciar();
        this.DestruirObstaculos();
        this.pontuacao.Reiniciar();
    }

    private void DestruirObstaculos()
    {
        ControlaObstaculo[] obstaculos = GameObject.FindObjectsOfType<ControlaObstaculo>();
        foreach(ControlaObstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }
}
