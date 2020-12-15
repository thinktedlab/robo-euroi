using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    private Controlador_HUD ch;
    private Animator anim;
    //AUDIO GAME --------------------------
    private int energiaEUROI;
    public Transform Pai;
    private feedback fb; //feedback de vida
    public AudioClip caindonegativo;
    public AudioClip pegandopositivo;
    private MusicaForaDoJogo somGeralJogo;
    public AudioSource SonsEuroi;
    public static bool acaFinal; // vitoria ou derrota
    public float tempoEmFase;
    private GameObject ControladorMusica;
    //Bools
    public static string motivoDerrota;


    public List<string> trajeto = new List<string>();

    public int total_coletaveis = 1;
    public bool escudo = false;
    private vida vida_euroi;//SCRIPT VIDA --------------------------------
    int Coletas = 0;// Variavel que vai verificar a quantidade de Itens (PECAS) Coletadas ----
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Awake()
    {
        acaFinal = false;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        ch = GameObject.Find("CONTROLE").GetComponent<Controlador_HUD>();
        this.gameObject.SetActive(true);
        vida_euroi = GameObject.FindObjectOfType<vida>();
    }
    void Start()
    {
        BotaoBullet.pressing = false;

        fb = GameObject.Find("feedback").GetComponent<feedback>();
        somGeralJogo = GameObject.FindGameObjectWithTag("ControladorInicial").GetComponent<MusicaForaDoJogo>();

        somGeralJogo.tocarMusicaAleatoriaFase(); //muda de musica ao iniciar, pega uma musica aleatoria
        setEnergy(8);
        anim.SetBool("nochao", true);
        anim.SetBool("movendo", false);
        anim.SetBool("morte", false);
        anim.SetBool("ataque", false);
    }
    void Update()
    {
        tempoEmFase += 1* Time.deltaTime;
        //SOM DO JOGO --------------------------------------------
        if (PlayerPrefs.GetInt("som") == 1)
        {
            SonsEuroi.mute = false;
        }
        else
        {
            SonsEuroi.clip = null;
        }
    }
    // Euroi Recebendo DANO --------------------- 
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("PlataformaMovel"))
        {
            gameObject.transform.SetParent(colisor.gameObject.transform);
        }
    }
    //Tirar o movimento a plataforma do Player---------------------------
    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.CompareTag("PlataformaMovel"))
        {
            gameObject.transform.SetParent(Pai.transform);
        }
    }
    //Col com objeto vitoria
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("energia_positiva"))
        {
            if ((PlayerPrefs.GetInt("toque") != 0))
            {
                SonsEuroi.PlayOneShot(pegandopositivo);//TOCANDO SOM ----------
            }

        }
        if (col.gameObject.CompareTag("bulletBoss"))
        {
            this.removeEnergy(3);
        }
        if (col.gameObject.CompareTag("escudo"))
        {
            escudo = true;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("ObjetoVitoria"))
        {
            Coletas++;
            Destroy(col.gameObject);
            if (Coletas == total_coletaveis)
                StartCoroutine(vitoria(2f));
        }
        else if (col.gameObject.CompareTag("Inimigo"))
        {
            // Verifica se ele morreu apos entrar em contato com o inimigo
            if(this.getEnergy() <= 0)
            {
                Personagem.motivoDerrota = "Mecanica"; // Provavelmente o motivo da morte foi uma falha de Mecanica, já que ele entrou sem querer em contato com o inimigo
            }
            if (col.gameObject.name == "Boss")
            {
                Personagem.motivoDerrota = "Mecanica"; // Provavelmente o motivo da morte foi uma falha de Mecanica, já que ele entrou sem querer em contato com o inimigo
                this.removeEnergy(8);
            }
            else
            {
                this.removeEnergy(3);
                Destroy(col.gameObject);//Destroi o inimigo
            }
        }
    }
    //Metodos Get Set
    public void removeEnergy(int energy)
    {
        if (getEnergy() > 0)
        {
            if (escudo)
            {
                escudo = false;
            }
            else
            {
                if ((PlayerPrefs.GetInt("toque") != 0))
                {
                    SonsEuroi.PlayOneShot(caindonegativo);
                }
                if (this.getEnergy() - energy <= 0)
                {
                    this.setEnergy(0);
                    StartCoroutine(morte());
                }
                else
                {
                    fb.changeFeed(energy, true);
                    this.energiaEUROI -= energy;
                }
            }
        }
    }

    public void addEnergy(int energy)
    {
        fb.changeFeed(energy, false);
        if (this.energiaEUROI + energy < 8)
        {
            this.energiaEUROI += energy;
        }
        else
        {
            //pega a vida maxima
            this.energiaEUROI = 8;
        }
    }
    public void setEnergy(int energy)
    {
        this.energiaEUROI = energy;
    }
    public int getEnergy()
    {
        return this.energiaEUROI;
    }
    public IEnumerator morte()
    {
        acaFinal = true;
        somGeralJogo.tocarMusicar(2);
        anim.SetBool("morte", true);
        yield return new WaitForSeconds(2);
        ControllerCaptura.captura.incrementaTentativas(SeletionFase.FaseAtual);
        ControllerCaptura.captura.adicionarNovaSessao(SeletionFase.FaseAtual, trajeto, "derrota", tempoEmFase, motivoDerrota);
        Debug.Log(motivoDerrota);
        this.gameObject.SetActive(false);
        ch.StartCoroutine("Lose");
    }
    public IEnumerator vitoria(float tempoEspera)
    {
        ControllerCaptura.captura.incrementaTentativas(SeletionFase.FaseAtual);
        ControllerCaptura.captura.adicionarNovaSessao(SeletionFase.FaseAtual, trajeto, "vitoria", tempoEmFase);
        // Desbloqueio a fase seguinte
        if (PlayerPrefs.GetInt("Fases_Planeta1") == SeletionFase.FaseAtual)
        {
            // Atribuo a minha quantidade de fases no "Captura Dados", a quantidade de fases desbloqueadas
            ControllerCaptura.captura.fasesDesbloqueadas = PlayerPrefs.GetInt("Fases_Planeta1");
            PlayerPrefs.SetInt("Fases_Planeta1", SeletionFase.FaseAtual + 1);
        }
        acaFinal = true;
        somGeralJogo.tocarMusicar(1);
        yield return new WaitForSeconds(tempoEspera);
        ch.StartCoroutine("vitoria");
    }
}
