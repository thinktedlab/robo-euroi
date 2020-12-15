using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaNegativas : MonoBehaviour
{
    private Personagem personagem;
	private feedback fb;

    void Start()
    {
        personagem = GameObject.Find("Personagem").GetComponent<Personagem>();
		fb = GameObject.Find("feedback").GetComponent<feedback>();
    }
    void OnCollisionEnter2D(Collision2D coli)
    {
        // Adicionando o trajeto do personagem (deve ser feito aqui, pois aqui é verificado o toque do pé do personagem em determinado local)
        personagem.trajeto.Add(coli.gameObject.name);
        if (coli.gameObject.CompareTag("NegativeChao"))
        {
            int retirar = coli.gameObject.name.IndexOf("-") + 1;
            int valor = int.Parse(coli.gameObject.name[retirar].ToString());
            personagem.removeEnergy(valor);
            if (personagem.getEnergy() <= 0)
            {
                Personagem.motivoDerrota = "Logica"; // Provavelmente o motivo da derrota foi uma falha logica, já que ele pulou numa plataforma errada
            }
            fb.changeFeed(valor,true);
        }
        else if ( coli.gameObject.CompareTag("LARVAVERDE"))
        {
            personagem.escudo = false;
            Personagem.motivoDerrota = "Mecanica"; // Provavelmente o motivo da morte foi uma falha de Mecanica, já que ele caiu na lava e não alcançou a plataforma
            personagem.removeEnergy(8);
        }
    }
}
