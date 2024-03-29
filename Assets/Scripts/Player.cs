using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    // TODO: Reference to Rigidbody2D component should have class scope.
    Rigidbody2D rigidbody2D;

    // TODO: A float variable to control how high to jump / how much upwards
    // force to add.
    public float jumpForce = 10.0f;

    public bool isFalling = true;

    public int numOfJumps = 0;

    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;

    public int[] LevelStage = new int[] { 0, 1, 2, 3};

    private Vector2 startPos = new Vector2(-10,-4);
    [SerializeField] private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        // TODO: Use GetComponent to get a reference to attached Rigidbody2D
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFalling || numOfJumps < 2){
            if(Input.GetKeyDown(KeyCode.Space))
                {
                    rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    numOfJumps++;
                }
            }
        horizontal = Input.GetAxisRaw("Horizontal");
        
        Flip();

        if(transform.position.y < -7){
            transform.position = startPos;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("On collision enter");
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = false;
            numOfJumps = 0;
        }
        else if (other.gameObject.CompareTag("Door")){
            gameObject.transform.position = startPos;

        }
    }



    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }

    private void FixedUpdate(){

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    
    }

    private void Flip(){
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
