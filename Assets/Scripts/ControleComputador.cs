using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleComputador : MonoBehaviour
{
    [SerializeField]
    private float intervalo;
    private ControlaAviao aviao;
    private void Start()
    {
        aviao = GetComponent<ControlaAviao>();
        StartCoroutine(Impulsionar());
    }

    private IEnumerator Impulsionar()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalo);
            aviao.DarImpulso();
        }
    }
}
