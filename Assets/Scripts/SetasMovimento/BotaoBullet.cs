using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotaoBullet : MonoBehaviour, IPointerUpHandler, IPointerDownHandler{
	public static bool pressing ;

	public void OnPointerDown(PointerEventData eventData){
		pressing = true;
	}
	public void OnPointerUp(PointerEventData eventData){
		pressing = false;
	}
}
