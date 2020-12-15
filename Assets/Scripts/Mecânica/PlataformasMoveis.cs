using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasMoveis : MonoBehaviour {
	public Transform Plat,P_A,P_B; // Pa= Ponto A, PB = Ponto b
	public float speed;

	//Varia o Ponto -----------------
	IEnumerator Start(){
		while (true) {
			yield return Repeting(Plat,P_A,speed);
			yield return Repeting(Plat,P_B,speed);
		}
	}
	//Anda Ate chegar no Ponto -------------------
	IEnumerator Repeting(Transform plataform,Transform target,float speed){
		while (plataform.position!=target.position) {
			plataform.position = Vector2.MoveTowards(plataform.position,target.position,speed*Time.deltaTime);
			yield return null;
		}
	}
}
