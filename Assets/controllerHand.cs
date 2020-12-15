using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerHand : MonoBehaviour
{
    public Sprite[] images;
    private Image image;
    private int posi;
    private Personagem personagem;
    void Start()
    {
        image = GetComponent<Image>();
        personagem = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
    }
    private void Update()
    {
        posi = personagem.getEnergy() - 1;
        if (posi >= 0)
        {
            image.sprite = images[posi];
        }
    }
}
