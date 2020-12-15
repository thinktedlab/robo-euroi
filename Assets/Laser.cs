using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider2;
    public Transform spawnLaser;

    Vector2[] vector3s = new Vector2[2];

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider2 = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss.deveAtacar)
        {
            lineRenderer.enabled = true;
            edgeCollider2.enabled = true;

            vector3s[0] = new Vector3(Boss.positionPerson.x, Boss.positionPerson.y);
            vector3s[1] = spawnLaser.position;

            if(vector3s[0].y >= vector3s[1].y)
            {
                vector3s[0].x-= 1f;
            }else if(vector3s[0].y > vector3s[1].y)
            {
                vector3s[0].x -= 2f;
                vector3s[0].y -= 2f;
            }

            lineRenderer.SetPosition(0, vector3s[0]);
            lineRenderer.SetPosition(1, vector3s[1]);

            edgeCollider2.points = vector3s.ToArray();
        }
        else
        {
            lineRenderer.enabled = false;
            edgeCollider2.enabled = false;
        }
    }
}
