using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class vida : MonoBehaviour {
	private SpriteRenderer EnergiaRobo;// Energia Atual -- Imagen
	public Sprite [] energias;//ENERGIA EM CIMA DO EUROI -------
	public Text numeroenergia;//AUXILIADOR ENERGIA --- NUMERO
	public static int pos;
	private Personagem personagem;
	void Awake(){
		personagem = GameObject.Find("Personagem").GetComponent<Personagem>();
		EnergiaRobo = GetComponent<SpriteRenderer> ();

	}
	void Update(){
		pos = personagem.getEnergy();
		if (pos <= 0) {
			pos = 0;
		}
		if (pos > 8) {
			pos = 8;
		}
		EnergiaRobo.sprite = energias [pos];
		numeroenergia.text = pos.ToString ();
	}
}