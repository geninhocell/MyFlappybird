using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorMultiplayer : Diretor
{
    [SerializeField]
    private int pontosParaReviver;
    private Jogador[] jogadores;
    private bool alguemMorto;
    private int pontosDesdeAMorte;
    private InterfaceCanvasInativo interfaceInativa;

    protected override void Start()
    {
        base.Start();
        jogadores = GameObject.FindObjectsOfType<Jogador>();
        interfaceInativa = GameObject.FindObjectOfType<InterfaceCanvasInativo>();
    }

    public void AvisarQueAlguemMorreu(Camera camera)
    {
        if (alguemMorto)
        {
            interfaceInativa.Sumir();
            FinalizarJogo();
        }
        else
        {
            interfaceInativa.Mostrar(camera);
            alguemMorto = true;
            pontosDesdeAMorte = 0;
            interfaceInativa.AtualizarTexto(pontosParaReviver);
        }
    }
    public void ReviverSePrecisar()
    {
        if (alguemMorto)
        {
            pontosDesdeAMorte++;
            interfaceInativa.AtualizarTexto(pontosParaReviver - pontosDesdeAMorte);
            if(pontosDesdeAMorte >= pontosParaReviver)
            {
                interfaceInativa.Sumir();
                ReviverJogadores();
            }
        }
    }

    private void ReviverJogadores()
    {
        alguemMorto = false;
        foreach (var jogador in jogadores)
        {
            jogador.Ativar();
        }
    }

    public override void ReiniciarJogo()
    {
        base.ReiniciarJogo();
        ReviverJogadores();
    }
}
