using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Cai : MonoBehaviour
{
 
 private void OnCollisionEnter2D(Collision2D other) {
     if(other.gameObject.CompareTag("LARVAVERDE")){
             Destroy(this.gameObject);
     }
 }
}