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
        if(Input.GetKeyDown(KeyCode.D)){
            rigidbody2D.gameObject.transform.position += new Vector3(1,0,0);
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
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isFalling = true;
        }
    }
}
