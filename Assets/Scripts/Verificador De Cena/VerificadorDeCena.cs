using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VerificadorDeCena : MonoBehaviour {
	public static bool Criado;

	void Awake(){
		if (!Criado) {
			DontDestroyOnLoad (this.gameObject);
			Criado = true;
		}
	}

	public void VoltarCena(string Cena){
		SceneManager.LoadScene(Cena);
	}
}
