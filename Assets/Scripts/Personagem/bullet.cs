using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
    }
    void Update()
    {
        transform.Translate(new Vector3(10, 0, 0) * Time.deltaTime);
    }
    IEnumerator fire()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
