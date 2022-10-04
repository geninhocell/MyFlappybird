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

    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
    }

    private void Start()
    {
        dificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }
    void Update()
    {
        this.cronometro -= Time.deltaTime;
        if(this.cronometro <= 0)
        {
            GameObject.Instantiate(this.manualDeInstrucoes, this.transform.position, Quaternion.identity);
            this.cronometro = Mathf.Lerp(tempoParaGerarFacil, tempoParaGerarDificil, dificuldade.Dificuldade);
        }
    }
}
