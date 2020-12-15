using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cima : MonoBehaviour, IPointerDownHandler
{
    public static bool pressing;


    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
    }
}
