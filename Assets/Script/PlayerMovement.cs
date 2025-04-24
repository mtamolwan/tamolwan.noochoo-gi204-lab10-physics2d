using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private Rigidbody2D rb2d;

    //walk L-R
    [SerializeField] public float speed;
    float move; // store input

    //Jump
    [SerializeField] float jumpForce;
    [SerializeField] bool isJumping;
    


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //walk L-R
        move = Input.GetAxis("Horizontal"); // x axis
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        //jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x , jumpForce));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //check jumping
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
