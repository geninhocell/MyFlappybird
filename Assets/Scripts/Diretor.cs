using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    private ControlaAviao controlaAviao;
    private Pontuacao pontuacao;
    private InterfaceGameOver interfaceGameOver;

    protected virtual void Start()
    {
        this.controlaAviao = GameObject.FindObjectOfType<ControlaAviao>();
        this.pontuacao = GameObject.FindObjectOfType<Pontuacao>();
        this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
    }
    public void FinalizarJogo()
    {
        Time.timeScale = 0f;
        this.pontuacao.SalvarRecorde();
        this.interfaceGameOver.MostrarInterface();
    }

    public virtual void ReiniciarJogo()
    {
        this.interfaceGameOver.EsconderInterface();
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
