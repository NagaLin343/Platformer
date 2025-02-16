using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rd;
    private bool isGrounded;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float move = Input.GetAxisRaw("Horisontal");
        Vector2 newVelocity = new Vector2(move * speed, rd.linearVelocity.y);
        rd.linearVelocity = newVelocity;

       
    }

    void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector2 jumpVelocity = new Vector2(rd.linearVelocity.x, jumpForce);
            rd.linearVelocity= jumpVelocity;
            isGrounded = false;
        }

    }


    void OnCollisionEner2D(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
