using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
[RequireComponent(typeof(Rigidbody2D))]

public class Boss : MonoBehaviour
{   
    public Rigidbody2D Rb;
    public Rigidbody2D PlayerRb;
    public float speed = 0.5f;
    public Transform target;
    private Vector2 VectorTarget;
    private Vector2 position;
    public float maxHealth = 400f;
    public float currentHealth;
    public HealthBar healthBar;
    public Text attackText;
    private GameObject textObj;
    private GameObject PlayerObj;
    private GameObject Canvas;
    private GameObject HealthBarObj;
    private double counter = 0;
    private static double AttackCounter = 0;
    private Vector3 playerLocation = new Vector3(0,0,0);
    private Animator animator;


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
        if((Math.Abs(playerLocation.x - this.gameObject.transform.position.x) <= 7) && (Math.Abs(playerLocation.y - this.gameObject.transform.position.y) <= 4)){
            textObj.SetActive(true);
            attackText.text = "The Enemy is about to attack in " + (3 - (int) counter);
            Player test = target.gameObject.GetComponent<Player>();
            if(counter >= 3){
                    test.TakeDamage(25);
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
        
    


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        textObj = new GameObject();
        Canvas = GameObject.Find("Canvas");
        textObj.transform.parent = Canvas.transform;
        textObj.AddComponent<Text>();
        attackText = textObj.GetComponent<Text>();
        textObj.SetActive(false);
        PlayerObj = GameObject.Find("Player");
        PlayerRb = PlayerObj.GetComponent<Rigidbody2D>();
        Rb = GetComponent<Rigidbody2D>();
        target = PlayerObj.GetComponent<Transform>();
        attackText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        textObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        attackText.color = Color.white;
        attackText.verticalOverflow = VerticalWrapMode.Overflow;
        attackText.horizontalOverflow = HorizontalWrapMode.Overflow;
        HealthBarObj = GameObject.Find("HealthBar");
        HealthBarObj = Instantiate(HealthBarObj, Canvas.transform);
        healthBar = HealthBarObj.GetComponent<HealthBar>();
        HealthBarObj.transform.localScale = new Vector3(1.5f, 1.5f,1.5f);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = PlayerObj.GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        AttackCounter += Time.deltaTime;
        AttackPlayer();
        GoToPlayer();
        if(transform.position.y <= -7){
            transform.position = new Vector3(5, -4, 0);
        }
        DoDamage(20);
        healthBar.SetHealth(currentHealth);
<<<<<<< HEAD
        healthBar.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2.0f);
        textObj.transform.position = new Vector2(transform.position.x - 1.0f, transform.position.y + 2.5f);
=======
        healthBar.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 3.0f);
        textObj.transform.position = new Vector2(transform.position.x - 1.0f, transform.position.y + 3.5f);
<<<<<<< HEAD

        if (currentHealth <= 0f)
        {
            SceneManager.LoadScene("VictoryScene");
        }
>>>>>>> ccf363aeb282ab07458d82b0d8ac1b4831b4f52a
=======
>>>>>>> parent of ccf363a (Finished the game)
    }

    public void DoDamage(float damage)
    {
        Vector3 playerLocation = target.transform.position;
        healthBar.transform.position = new Vector2(0.0f, 1.0f);
        if((Math.Abs(playerLocation.x - this.gameObject.transform.position.x) <= 5) && (Math.Abs(playerLocation.y - this.gameObject.transform.position.y) <= 4)){
            if(Input.GetKeyDown(KeyCode.R)){
                if(AttackCounter > .5f){
                TakeDamage(20);
                healthBar.SetHealth(currentHealth);
                AttackCounter = 0.0f;
                animator.SetTrigger("Attack1");
                }
                }
            if (currentHealth <= 0){ 
                    gameObject.SetActive(false);
                    healthBar.NoHealth();
                    textObj.SetActive(false);
                    Destroy(this);
                    SceneManager.LoadScene("Victory Screen");
                }           
            }
        }

    
    }

    

