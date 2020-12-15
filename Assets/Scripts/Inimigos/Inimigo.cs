using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private float speed;
    private Animator anim;
    public Rigidbody2D RBenemy;
    public SpriteRenderer Enemy;
    public float Distance;
    private bool derrotado;
    void Start()
    {
        this.anim = gameObject.GetComponent<Animator>();
        Enemy.flipX = false;
        StartCoroutine("VirarPersonagem");
        speed = 0.7f;
        derrotado = false;
        RBenemy.velocity = new Vector2(speed, RBenemy.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            derrotado = true;
            StartCoroutine(morte());
        }
    }
    IEnumerator morte()
    {
        this.anim.SetTrigger("morte");
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
    //Verifica Colisao --------------------------------------------------
    IEnumerator VirarPersonagem()
    {
        Enemy.flipX = !Enemy.flipX;
        if (derrotado==false)
        {
            if (!Enemy.flipX)
            {
                RBenemy.velocity = new Vector2(-speed, RBenemy.velocity.y);
            }
            else
            {
                RBenemy.velocity = new Vector2(speed, RBenemy.velocity.y);
            }
            yield return new WaitForSeconds(Distance);
            StartCoroutine("VirarPersonagem");
        }
        else
        {
            RBenemy.velocity = new Vector2(0, 0);
        }
    }
}
