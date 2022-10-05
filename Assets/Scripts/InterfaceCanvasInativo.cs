using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceCanvasInativo : MonoBehaviour
{
    [SerializeField]
    private GameObject fundo;
    [SerializeField]
    private Text texto;
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    
    public void Mostrar(Camera camera)
    {
        fundo.SetActive(true);
        //mudar camera
        canvas.worldCamera = camera;
    }

    public void AtualizarTexto(int pontosParaReviver)
    {
        texto.text = pontosParaReviver.ToString();
    }

    public void Sumir()
    {
        fundo.SetActive(false);
    }
}
