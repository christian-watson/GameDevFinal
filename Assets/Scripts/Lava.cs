using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class Lava : MonoBehaviour
{
    public Player player;
    
    public Rigidbody2D rigidbody2D;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(10);
            rigidbody2D.AddForce(Vector3.up * 10, ForceMode2D.Impulse);
        }
     }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
