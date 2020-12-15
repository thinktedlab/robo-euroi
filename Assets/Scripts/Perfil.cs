using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perfil : MonoBehaviour
{   
    
    public void setSexo(string sexo)
    {
        ControllerCaptura.captura.sexo = sexo;
    }
    public void setFaixaEtaria(string faixa)
    {
        ControllerCaptura.captura.faixaEtaria = faixa;
        SceneManager.LoadScene("Menu");
    }
}
