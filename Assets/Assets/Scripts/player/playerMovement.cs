using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //allows the object's run/jump speeds to be customized
    [SerializeField]private float walkSpeed;
    [SerializeField]private float height;
    [SerializeField]private float runSpeed;

    private bool grounded;
    private Rigidbody2D body;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        //assigns the A, D, leftArrow, and rightArrow to horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2((horizontalInput) * walkSpeed, body.velocity.y);

        //assigns LeftShift to be a run button
        if(horizontalInput != 0f && Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = new Vector2((horizontalInput) * runSpeed, body.velocity.y);
        }

        //checks the direction of the object then flips it
        if (horizontalInput > 0.01f)
            transform.localScale = Vector2.one;
        if (horizontalInput < -0.01f)
            transform.localScale = new Vector2(-1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded && Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = new Vector2((horizontalInput) * runSpeed, height + (runSpeed/4));
            grounded = false;
        }
        if (Input.GetKey(KeyCode.Space) && grounded && Input.GetKey(KeyCode.LeftShift) == false)
        {
            body.velocity = new Vector2((horizontalInput) * walkSpeed, height);
            grounded = false;
        }

    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, height);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
