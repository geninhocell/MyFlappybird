using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;
    [SerializeField]
    private GameObject manualDeInstrucoes;
    private float cronometro;
    private ControleDeDificuldade dificuldade;
    private bool parado;

    public void Parar()
    {
        parado = true;
    }

    public void Recomecar()
    {
        parado = false;
    }

    private void Awake()
    {
        cronometro = tempoParaGerarFacil;
    }

    private void Start()
    {
        dificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }
    private void Update()
    {
        if (parado)
        {
            return;
        }
        cronometro -= Time.deltaTime;
        if(cronometro <= 0)
        {
            GameObject.Instantiate(manualDeInstrucoes, transform.position, Quaternion.identity);
            cronometro = Mathf.Lerp(tempoParaGerarFacil, tempoParaGerarDificil, dificuldade.Dificuldade);
        }
    }
}
