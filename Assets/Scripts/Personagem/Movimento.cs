using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Movimento : MonoBehaviour
{
    // Sons------------
    private AudioSource SomEuroi;
    public AudioClip SomPulo;
    //##################
    private Rigidbody2D rb;
    private SpriteRenderer Euroi;
    private Animator anim;
    private Transform Tr;
    private float velocidade;//Velocidade do Personagem
    //Verificando Toque no Chao ------------------------
    bool toquechao; //SE TA TOCANDO -- BOOL
    public Transform tanochao;//OBJETO NO CHÃO(VERIFICANDO TOQUE);
    float raiocoli;//RAIO DE COLISAO;
    public LayerMask issochao;
    bool Virado;
    //#################################################
    void Awake()
    {
        velocidade = 3.5f;
        raiocoli = 0.3f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        SomEuroi = GetComponent<AudioSource>();
        Tr = GetComponent<Transform>();
        Euroi = GetComponent<SpriteRenderer>();
        anim.SetBool("nochao", true);
        anim.SetBool("movendo", false);
        anim.SetBool("morte", false);
        anim.SetBool("ataque", false);
    }
    void FixedUpdate()
    {
        toquechao = Physics2D.OverlapCircle(tanochao.position, raiocoli, issochao);//Verificando se ta tocando no chao
        //Tocando no chao------------------------------------------------------
        if (toquechao)
        {
            anim.SetBool("nochao", true);//SE TA NO CHAO === TA NO CHAO ----------
        }

        //Se n ta no chao ta pulado -------------
        if (!toquechao)
        {
            anim.SetBool("nochao", false);
        }
        movimento();
        pulo();
    }
    void movimento()
    {
        Vector3 move = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * velocidade;
        if (move.x < 0)
        {
            Virado = true;
            anim.SetBool("movendo", true);
            Euroi.flipX = true;
        }
        if (move.x > 0)
        {
            Virado = false;
            anim.SetBool("movendo", true);
            Euroi.flipX = false;
        }
        //Andando --- PARANDO DE ANDAR
        if (move.x == 0)
        {
            anim.SetBool("movendo", false);
        }
    }
    void pulo()
    {
        if (toquechao && Cima.pressing)
        {
            rb.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
            if ((PlayerPrefs.GetInt("toque") != 0))
                SomEuroi.PlayOneShot(SomPulo);
        }
        Cima.pressing = false;
    }
}