using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }
   /*
    private void Update()
    {
        lineRenderer.SetPositions(new Vector3[] { transform.position, positionPerson  + ( transform.right * _laseLenght) });
        // se chegar a posicao do personagem ocorre uma explosao
        if(transform.position == positionPerson)
        {
            Destroy(this.gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, positionPerson, 10*Time.deltaTime);
    }
    IEnumerator tempoDisparo()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
        }
    }
    */
}
