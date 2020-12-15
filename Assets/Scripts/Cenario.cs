using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;

public class Cenario : MonoBehaviour
{

    public GameObject TextoAuxiliador;// Texto Auxiliador Numero ---------------------

    void Update()
    {
        if (PlayerPrefs.GetInt("auxilio") == 1)
        {
            TextoAuxiliador.gameObject.SetActive(true);
        }
        else
        {
            TextoAuxiliador.gameObject.SetActive(false);
        }
    }
}
