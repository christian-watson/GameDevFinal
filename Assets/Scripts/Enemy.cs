using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Rigidbody2D PlayerRb;
    public float speed = 2.0f;
    public Transform target;

    private static double counter = 5;
    private Vector2 VectorTarget;
    private Vector2 position;

    private Vector3 playerLocation = new Vector3(0,0,0);

    private void GoToPlayer(){
        Vector3 playerLocation = target.transform.position;
        if(!(Math.Abs(playerLocation.x - transform.position.x) <= 2)){
            transform.position = Vector3.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
            }
        }

     private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Rb.AddForce(Vector3.up, ForceMode2D.Impulse);
        }
     }

    

    private void AttackPlayer(){
        Vector3 playerLocation = target.transform.position;
        if((Math.Abs(playerLocation.x - transform.position.x) <= 2) && (Math.Abs(playerLocation.y - transform.position.y) <= 4)){
            Player test = target.gameObject.GetComponent<Player>();
            if(counter >= 2){
                test.TakeDamage(5);
                counter = 0;
            }
        }
    }

    private void SwitchPlatforms(){
    
    }
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        AttackPlayer();
        GoToPlayer();
        if(transform.position.y <= -7){
            transform.position = new Vector3(5, -4, 0);
        }
    }
}
