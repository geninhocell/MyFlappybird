using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAviao : MonoBehaviour
{
    private Rigidbody2D fisica;
    [SerializeField]
    private float forca;
    private Diretor diretor;
    private Vector3 posicaoInicial;
    private bool deveImpulsionar;
    private Animator animacao;
    private void Awake()
    {
        this.fisica = GetComponent<Rigidbody2D>();
        this.posicaoInicial = this.transform.position;
        animacao = GetComponent<Animator>();
    }

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<Diretor>();
    }
    private void Update()
    {
        if (Input.GetButtonDown(Tags.Fire1))
        {
            //Debug.Log("Clicou");
            this.deveImpulsionar = true;
        }
        animacao.SetFloat(Tags.VelocidadeY, fisica.velocity.y);
    }

    private void FixedUpdate()
    {
        if (deveImpulsionar)
        {
            this.deveImpulsionar = false;
            this.Impulsionar();
        }
    }
    public void Reiniciar()
    {
        this.transform.position = this.posicaoInicial;
        this.fisica.simulated = true;
    }

    private void Impulsionar()
    {
        this.fisica.velocity = Vector2.zero;
        this.fisica.AddForce(Vector2.up * this.forca, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.fisica.simulated = false;
        this.diretor.FinalizarJogo();
    }
}
