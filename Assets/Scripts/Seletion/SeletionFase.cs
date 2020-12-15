using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SeletionFase : MonoBehaviour
{
    public static int FaseAtual;
    public Button[] Selecionadores;
    public Image[] Images_Selecionadores;
    public Image historiaFase;
    public Image historiaFinal;
    void Awake()
    {
        PlayerPrefs.SetString("Selecao", SceneManager.GetActiveScene().name);
        //Verifica se existe fase disposnivel/Caso Nao -- Abre a Fase 1.
        if (PlayerPrefs.GetInt("PrimeiraVez") != 1)
        {
            PlayerPrefs.SetInt("PrimeiraVez", 1);
            PlayerPrefs.SetInt("Fases_Planeta1", 1);
        }

        if(PlayerPrefs.GetInt("Fases_Planeta1") == 14 && PlayerPrefs.GetInt("finalizouPrimeiraParte") != 1){
            historiaFinal.gameObject.SetActive(true);
            PlayerPrefs.SetInt("finalizouPrimeiraParte", 1);
        }

            Destravar();

            //Colocar a imagem de travo nas fases que nao estao disponiveis -----------------------------
            for (int i = 0; i < Selecionadores.Length; i++)
            {
                if (Selecionadores[i].IsInteractable() == false)
                {
                    Images_Selecionadores[i].sprite = Resources.Load<Sprite>("TelaTrava");
                }
            }
        

    }
    public void fecharHistoria()
    {
        historiaFinal.gameObject.SetActive(false);
    }
    //Destrava ate as Fases que estao Disponiveis -------------------
    void Destravar()
    {
        //Colocando a imagem em n Interactable
        //######################### RETIRAR O -1 ##################################
        //######################### RETIRAR O -1 ##################################
        //######################### RETIRAR O -1 ##################################
        //######################### RETIRAR O -1 ##################################
        //######################### RETIRAR O -1 ##################################
        //######################### RETIRAR O -1 ##################################
        if(PlayerPrefs.GetInt("Fases_Planeta1") > 13)
        {
            PlayerPrefs.SetInt("Fases_Planeta1", 13);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("Fases_Planeta1"); i++)
        {
            // caso tenha sido desbloqueada uma nova fase, o status da fase é alterado
            ControllerCaptura.captura.capturaFases[i].status = "desbloqueado";
            Selecionadores[i].interactable = true;
        }
        ControllerCaptura.captura.fasesDesbloqueadas = PlayerPrefs.GetInt("Fases_Planeta1");
    }

    public void iniciarFaseAposHistoria()
    {
        if(FaseAtual == 13) {
            SceneManager.LoadScene("Planeta1_Fase12");
        }
    }
    //Seleciona a Fase e Carrega a Cena ---------------
    public void SelecaoFase(int num)
    {
        FaseAtual = num;//FASE ATUAL ----------- RECEBE O NUMERO PARAMETRO ENVIADO -----
        switch (num)
        {
            case 1:
                SceneManager.LoadScene("Planeta1_Fase1");
                break;
            case 2:
                SceneManager.LoadScene("Planeta1_Fase1.2");
                break;
            case 3:
                SceneManager.LoadScene("Planeta1_Fase2");
                break;
            case 4:
                SceneManager.LoadScene("Planeta1_Fase3");
                break;
            case 5:
                SceneManager.LoadScene("Planeta1_Fase4");
                break;
            case 6:
                SceneManager.LoadScene("Planeta1_Fase5");
                break;
            case 7:
                SceneManager.LoadScene("Planeta1_Fase6");
                break;
            case 8:
                SceneManager.LoadScene("Planeta1_Fase7");
                break;
            case 9:
                SceneManager.LoadScene("Planeta1_Fase8");
                break;
            case 10:
                SceneManager.LoadScene("Planeta1_Fase9");
                break;
            case 11:
                SceneManager.LoadScene("Planeta1_Fase10");
                break;
            case 12:
                SceneManager.LoadScene("Planeta1_Fase11");
                break;
            case 13:
                historiaFase.gameObject.SetActive(true);
                historiaFase.sprite = Resources.Load<Sprite>("Group50");
                break;
        }
    }
}
