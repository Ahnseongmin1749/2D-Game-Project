using UnityEngine;

public class Player_Platformer : MonoBehaviour
{
    Rigidbody2D rigid;
    float move;
    public float speed;
    public float jump;

    Animator anim;
    SpriteRenderer spriteRenderer;
    bool isjumping;
    RaycastHit2D ray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //Jump
        if (Input.GetButtonDown("Jump") && !isjumping)
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            isjumping = true;
        }

        //Jump Animation
        anim.SetBool("isJump", isjumping);
        /*if (isjumping)
        { 
            if (rigid.linearVelocity.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }*/


        //Move Animation
        if (rigid.linearVelocity.x < 0)
        {
            anim.SetBool("ismoving", true);
            anim.SetInteger("xVelocity", (int)move);
        }
        else if (rigid.linearVelocity.x > 0)
        {
            anim.SetBool("ismoving", true);
            anim.SetInteger("xVelocity", (int)move);
        }
        else if (rigid.linearVelocity.x == 0)
        {
            anim.SetBool("ismoving", false);
            anim.SetInteger("xVelocity", (int)move);
        }
    }

    private void FixedUpdate()
    {
        //Move
        move = Input.GetAxisRaw("Horizontal");

        rigid.linearVelocity = new Vector2(move * speed, rigid.linearVelocity.y);

        //Ray
        if (rigid.linearVelocity.y < 0)
        {
            Debug.DrawRay(transform.position, Vector2.down * 1, new Color(1, 0, 0, 0.7f));

            ray = Physics2D.Raycast(transform.position, Vector2.down,
            1, LayerMask.GetMask("Platform"));
            if (ray.collider != null)
            {
                if (ray.collider.gameObject.layer == 10)
                {
                    isjumping = false;
                }

            }
        }

    }
}
