using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 2.0f;
    private Rigidbody enemyRB;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection=(player.transform.position -transform.position).normalized;
        enemyRB.AddForce(lookDirection * Speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
