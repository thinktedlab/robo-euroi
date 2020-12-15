using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer Euroi;
    //Sprict Vida ---------------
    //#########################
    // Som Do jogo --------------
    public AudioSource SomEuroi;
    public AudioClip Atirando;
    //##########################
    private Personagem personagem_euroi;
    //Tiro -----------------------
    public float firerate;
    public float NextFire;
    //############################
    public Transform bulletspawn;
    public GameObject BulletObjeto;
    // Use this for initialization
    void Start()
    {
        personagem_euroi = GetComponent<Personagem>();
        Euroi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame'
    void FixedUpdate()
    {
        if (BotaoBullet.pressing && Time.time > NextFire && PlayerPrefs.GetInt("pause") == 0 && PlayerPrefs.GetInt("morto") == 0)
        {
            if ((PlayerPrefs.GetInt("toque") != 0))
            {
                SomEuroi.PlayOneShot(Atirando);
            }
            Fire();
            anim.SetBool("ataque", true);
        }
        else
        {
            anim.SetBool("ataque", false);
        }
    }
    //Funcao para Atirar------------------------------------
    void Fire()
    {
        personagem_euroi.removeEnergy(1);
        anim.SetBool("ataque", true);
        NextFire = Time.time + firerate;
        //Clona o Objeto na posicao do bullet Spwan ------------------------
        GameObject clonebullet = Instantiate(BulletObjeto, bulletspawn.position, bulletspawn.rotation);
        if (Euroi.flipX)
        {
            clonebullet.transform.eulerAngles = new Vector3(0, 0, 180);//Vira com o personagem ----------------------
        }
    }
}
