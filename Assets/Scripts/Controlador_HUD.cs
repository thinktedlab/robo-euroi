using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controlador_HUD : MonoBehaviour
{
    private Toggle toque;
    private Toggle som;
    private Toggle auxilio;
    private Canvas botoes;
    private Animator fadeAnim;
    private GameObject painel_Pause;
    private MusicaForaDoJogo somGeralJogo;
    private GameObject textoAuxiliador;
    private void Update() {
        if(Personagem.acaFinal){
            botoes.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        fadeAnim = GameObject.Find("FadeGame").GetComponent<Animator>();
        StartCoroutine(desativarFade());
        botoes = GameObject.Find("CanvasBotoes").GetComponent<Canvas>();
        somGeralJogo = GameObject.FindGameObjectWithTag("ControladorInicial").GetComponent<MusicaForaDoJogo>();
        //buscarObjetosToggle
        toque = GameObject.Find("Toque").GetComponent<Toggle>();
        som = GameObject.Find("Audio").GetComponent<Toggle>();
        auxilio = GameObject.Find("Ajuda").GetComponent<Toggle>();
        textoAuxiliador = GameObject.Find("AuxiliadorTEXT");
        painel_Pause = GameObject.Find("PauseGame");
    }
    void Start()
    {
        painel_Pause.SetActive(false);
        this.verificarToggles();
    }
    IEnumerator desativarFade(){
        yield return new WaitForSeconds(1);
        fadeAnim.transform.localScale = new Vector3(0,0,0);
    }
    public IEnumerator Lose()
    {
        fadeAnim.transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(1);
        Restart();
    }
    public void OpenOptions()
    {
        painel_Pause.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Seletion()
    {
        somGeralJogo.tocarMusicar(0);
        SceneManager.LoadScene("SeletionFase1");
    }
    public IEnumerator vitoria()
    {
        fadeAnim.transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(1);
        Seletion();
    }
    public void Play()
    {
        painel_Pause.SetActive(false);
    }
    void verificarToggles()
    {
        if (PlayerPrefs.GetInt("som") == 0)
        {
            som.isOn = false;
        }
        else
        {
            som.isOn = true;
        }
        if (PlayerPrefs.GetInt("toque") == 0)
        {
            toque.isOn = false;
        }
        else
        {
            toque.isOn = true;
        }
        if (PlayerPrefs.GetInt("auxilio") == 0)
        {
            auxilio.isOn = false;
        }
        else
        {
            auxilio.isOn = true;
        }
    }
    public void modificarAtivacaoSom()
    {
        if (som.isOn)
        {
            PlayerPrefs.SetInt("som", 1);
        }
        else
        {
            PlayerPrefs.SetInt("som", 0);
        }
    }
    public void modificarAtivacaoToque()
    {
        if (toque.isOn)
        {
            PlayerPrefs.SetInt("toque", 1);
        }
        else
        {
            PlayerPrefs.SetInt("toque", 0);
        }
    }
    public void modificarAtivacaoAuxilio()
    {
        if (auxilio.isOn)
        {
            textoAuxiliador.SetActive(true);
            PlayerPrefs.SetInt("auxilio", 1);
        }
        else
        {
            textoAuxiliador.SetActive(false);
            PlayerPrefs.SetInt("auxilio", 0);
        }
    }
}
