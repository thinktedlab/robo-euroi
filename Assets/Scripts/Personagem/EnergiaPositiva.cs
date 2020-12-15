using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergiaPositiva : MonoBehaviour
{
    private Personagem personagem;
    public int valueEnergia; // valor a ser adicionado

    public Sprite[] energias;
    void Start()
    {
        personagem = GameObject.Find("Personagem").GetComponent<Personagem>();
        Debug.Log(valueEnergia - 1);
        if(valueEnergia-1 < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = energias[valueEnergia];
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = energias[valueEnergia-1];
        }
    }
    void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            personagem.addEnergy(valueEnergia);
            Destroy(this.gameObject);
        }
    }
}
