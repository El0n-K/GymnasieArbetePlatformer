using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float groundDistance;
    [SerializeField] float wallDistance;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
    Vector2 movementDirection;
    public bool isGrappling = false;
    bool wallToTheRight;
    bool wallToTheLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        movementDirection = new Vector2(xAxis * movementSpeed, rb.linearVelocityY);
        if (!isGrappling)
        {
            Move();
        }
       

        if(Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            Jump();
        }
    }

    private void Move()
    {
        rb.linearVelocity = movementDirection;
    }

    private void Jump()
    {
        if (GroundCheck())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (WallContactCheck() && !GroundCheck())
        {
            if (wallToTheRight)
            {
                rb.AddForce(new Vector2(-5,5) * jumpForce, ForceMode2D.Impulse);
                print("Jump from right to left");
            }
            else if (wallToTheLeft)
            {
                rb.AddForce(new Vector2(5, 5) * jumpForce, ForceMode2D.Impulse);
                print("Jump from left to right");
            }
        }
    }

    bool GroundCheck()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer))
        {
            return true;
        }

        return false;
    }

    bool WallContactCheck()
    {
        if (Physics2D.Raycast(transform.position, Vector2.left, wallDistance, wallLayer))
        {
            wallToTheLeft = true;
            wallToTheRight = false;
            return true;
        }
        else if (Physics2D.Raycast(transform.position, Vector2.right, wallDistance, wallLayer))
        {
            wallToTheLeft = false;
            wallToTheRight = true;
            return true;
        }

            return false;
    }
}


