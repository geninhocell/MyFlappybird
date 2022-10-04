using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaMaoPiscando : MonoBehaviour
{
    private SpriteRenderer imagem;

    private void Awake()
    {
        this.imagem = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(Tags.Fire1))
        {
            this.Desaparecer();
        }
    }

    private void Desaparecer()
    {
        this.imagem.enabled = false;
    }
}
