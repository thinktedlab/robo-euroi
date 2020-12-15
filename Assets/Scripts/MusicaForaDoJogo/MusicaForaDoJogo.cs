using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityGoogleDrive;

using System;
using System.IO;
using Firebase.Auth;

public class MusicaForaDoJogo : MonoBehaviour
{
    public AudioSource musicaFundo;
    public AudioClip[] sonsFundo;
    public AudioClip[] sonsFundosFase;
    public static float tempoTotalEmJogo; // Armazena tempo total que o usuario jogou
    /*1 - Som Menu
    2 - Som MusicaForaDoJogo
    3 - Som Vitoria
    4- Som Derrota*/
    void Awake()
    {
        if(PlayerPrefs.GetInt("PrimeiraVez") != 1)
        {
            PlayerPrefs.SetInt("som", 1);
            PlayerPrefs.SetInt("toque", 1);
            PlayerPrefs.SetInt("auxilio", 1);
        }
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine("MudarCena");   
    }

    //###########################################
    void Update()
    {
        tempoTotalEmJogo += 1 * Time.deltaTime;
        //verifica se musica esta desligada
        if (PlayerPrefs.GetInt("som") == 0)
        {
            musicaFundo.mute = true;
        }
        else
        {
            musicaFundo.mute = false;
        }
    }
    //###########################################
    IEnumerator MudarCena()
    {
        tocarMusicar(0);

        yield return new WaitForSeconds(2f);
        
        // As proximas 3 linhas são temporarias
        SceneManager.LoadScene("Perfil");
        ControllerCaptura.captura.emailJogador = "Anonimo@euroi.com"; // Adiciono o email do usuario
        ControllerCaptura.captura.dataHora = DateTime.Now.ToString(); // Adiciono o tempo de login do usuario
        /* Momentaneo comentado, esta parte do código era reponsavel por se conectar diretamente com o firebase
        Firebase.Auth.FirebaseUser user = Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser;
        if (user == null && Application.internetReachability != NetworkReachability.NotReachable )
        {
            SceneManager.LoadScene("Login");
        }
        else
        {
            // Caso ja logado
            ControllerCaptura.captura.emailJogador = user.Email; // Adiciono o email do usuario
            ControllerCaptura.captura.dataHora = DateTime.Now.ToString(); // Adiciono o tempo de login do usuario
            SceneManager.LoadScene("Perfil");
        }
        */
    }

    public void tocarMusicar(int index)
    {
        musicaFundo.clip = sonsFundo[index];
        musicaFundo.Play();
    }

    // Ao iniciar uma fase essa função é chamada e uma musica aleatoria na lista é chamada
    public void tocarMusicaAleatoriaFase()
    {
        int index = UnityEngine.Random.Range(0, 3);
        musicaFundo.clip = sonsFundosFase[index];
        musicaFundo.Play();
    }
}
