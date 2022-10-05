using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private Carrossel[] cenario;
    private GeradorDeObstaculos obstaculo;
    private ControlaAviao aviao;
    private bool estouMorto;
    private void Start()
    {
        cenario = GetComponentsInChildren<Carrossel>();
        obstaculo = GetComponentInChildren<GeradorDeObstaculos>();
        aviao = GetComponentInChildren<ControlaAviao>();
    }
    public void Desativar()
    {
        estouMorto = true;
        obstaculo.Parar();
        foreach(var carrocel in cenario)
        {
            carrocel.enabled = false;
        }
    }

    public void Ativar()
    {
        if (estouMorto)
        {
            estouMorto = false;
            aviao.Reiniciar();
            obstaculo.Recomecar();
            foreach (var carrocel in cenario)
            {
                carrocel.enabled = true;
            }
        }
    }
}
