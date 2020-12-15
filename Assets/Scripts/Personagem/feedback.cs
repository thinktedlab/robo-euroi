using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback : MonoBehaviour
{
    private SpriteRenderer feeds;
    private Animation anim;
    private Transform personagem;
    // Start is called before the first frame update
    void Start()
    {
        personagem = GameObject.Find("Personagem").GetComponent<Transform>();
        anim = GetComponent<Animation>();
        feeds = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(anim.isPlaying == true){
            this.gameObject.transform.localScale = new Vector3(1,1,1);
        }else{
            this.gameObject.transform.localScale = new Vector3(0,0,0);
        }
        this.transform.position = new Vector3(personagem.position.x+0.5f,personagem.position.y+0.3f,personagem.position.z);

    }
    // Update is called once per frame
    public void changeFeed(int valor, bool perdendo)
    {
        if (perdendo)
        {
            string value = "-" + valor.ToString();
            feeds.sprite = Resources.Load<Sprite>("feed/" + value);
        }
        else
        {
            string value = "+" + valor.ToString();
            feeds.sprite = Resources.Load<Sprite>("feed/" + value);
        }
        anim.Play();
    }
}
