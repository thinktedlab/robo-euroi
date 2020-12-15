using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryBoard : MonoBehaviour {
	private int contador;

	void Awake(){
		contador = 0;
		voltar.gameObject.transform.localScale = new Vector3(0,0,0);
	}
	public Sprite[] Telas;
	public Image Atual;
	public GameObject voltar;

	public void Passarevolotar(int id){

		if (contador == 5 && id == 1) {
			SceneManager.LoadScene("SeletionFase1");
		}

		else if(contador < 5 && id == 1){
			contador++;
		}
		else if (id == 2 && contador > 0 ) {
			contador --;
		}

		if (contador == 0)
		{
			voltar.SetActive(false);
		}
		else
		{
			voltar.SetActive(true);
		}
		Debug.Log(contador);
		Debug.Log(id);
		Atual.sprite = Telas[contador];
	}
}
