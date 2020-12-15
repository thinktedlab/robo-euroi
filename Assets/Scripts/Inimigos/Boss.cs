using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    //public GameObject projetil;
    private float contadorTempoAtacar = 0;
    private int life = 0;
    public Slider sliderLife;

    public static bool deveAtacar = false;
    
    public static Vector3 positionPerson;

    public Animator animatorBoss;
    

    private void Start()
    {
        life = 8;
        sliderLife.value = life;
    }
    void Update()
    {
        verificarAtaque();
    }
    void verificarAtaque()
    {
        if(contadorTempoAtacar  >= 8)
        {
            contadorTempoAtacar = 0;
            StartCoroutine(atacar());
        }
        else
        {
            contadorTempoAtacar += Time.deltaTime;
        }
    }
   IEnumerator atacar()
    {
        if(PlayerPrefs.GetInt("pause") != 1)
        {
            positionPerson = GameObject.FindGameObjectWithTag("Player").transform.position;

            animatorBoss.SetBool("ataque", true);

            yield return new WaitForSeconds(1f);

            deveAtacar = true;

            yield return new WaitForSeconds(1f);

            animatorBoss.SetBool("ataque", false);
            deveAtacar = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("bullet"))
        {
            life--;
            sliderLife.value = life;
            if (life  <= 0)
            {
                animatorBoss.SetTrigger("morte");
                this.sliderLife.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
}
