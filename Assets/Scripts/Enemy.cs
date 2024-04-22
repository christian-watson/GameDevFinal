using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D Rb;
    public Rigidbody2D PlayerRb;
    public float speed = 2.0f;
    public Transform target;
    private static double counter = 0;
    private Vector2 VectorTarget;
    private Vector2 position;
    public float maxHealth = 100f;
    public float currentHealth;
    public HealthBar healthBar;
    public Text attackText;
    private GameObject textObj;

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
            Rb.AddForce(Vector3.up * 10000, ForceMode2D.Impulse);
        }
     }

    

    private void AttackPlayer(){
        Vector3 playerLocation = target.transform.position;
        if((Math.Abs(playerLocation.x - transform.position.x) <= 2) && (Math.Abs(playerLocation.y - transform.position.y) <= 4)){
            textObj.SetActive(true);
            attackText.text = "Dodge the attack in " + (3 - (int) counter) + "!";
            attackText.text = (3 - (int) counter) + "!";
            Player test = target.gameObject.GetComponent<Player>();
            if(counter >= 3){
                    test.TakeDamage(10);
                    counter = 0;
                }
            else{
                counter += Time.deltaTime;
            }
        }
        else{
            counter = 0;
            textObj.SetActive(false);
            }
        }
        
    
    private void SwitchPlatforms(){
    
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        textObj = GameObject.Find("attackText");
        attackText = textObj.GetComponent<Text>();
        textObj.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
        GoToPlayer();
        if(transform.position.y <= -7){
            transform.position = new Vector3(5, -4, 0);
        }
        DoDamage(20);
        
        healthBar.transform.position = gameObject.transform.position + new Vector3(0.0f, 1.5f, 0.0f);
        textObj.transform.position = new Vector2(transform.position.x, transform.position.y + 2.0f);
        textObj.transform.position = new Vector2(transform.position.x, transform.position.y + 1.0f);
    }

    public void DoDamage(float damage)
    {
        Vector3 playerLocation = target.transform.position;
        healthBar.transform.position = new Vector2(0.0f, 1.0f);
        if((Math.Abs(playerLocation.x - transform.position.x) <= 2) && (Math.Abs(playerLocation.y - transform.position.y) <= 4)){
            if(Input.GetKeyDown(KeyCode.R)){
                TakeDamage(20);
                }
            if (currentHealth <= 0){
                    gameObject.SetActive(false);
                    healthBar.NoHealth();
                    textObj.SetActive(false);
                }           
            }
        }
    }

    
