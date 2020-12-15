using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviarDados : MonoBehaviour
{
    public GameObject loading;

    public void Start()
    {
        loading.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
    public IEnumerator enviarDados()
    {
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("ControladorInicial").GetComponent<ControllerCaptura>().converterParaJson();
        loading.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
    public void abrirLoading()
    {
        loading.gameObject.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(enviarDados());
    }
}
