using UnityEngine;

public class Enemy_P : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextJumpdirection;
    public int nextJumpTime;
    RaycastHit2D ray;
    bool isjumping;
    Animator anim;
    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        Invoke("EnemyMove", 1);
    }

    void EnemyMove()
    {
        if (!isjumping)
        {
            nextJumpdirection = Random.Range(-1, 2);
            nextJumpTime = Random.Range(1, 4);
            isjumping = true;
            rigid.AddForce(new Vector2(nextJumpdirection * 3, 5), ForceMode2D.Impulse);
            Invoke("EnemyMove", nextJumpTime);
            
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Invoke("EnemyMove", nextJumpTime);
            nextJumpdirection = nextJumpdirection * -1;
            rigid.AddForce(new Vector2(nextJumpdirection * 3, 1), ForceMode2D.Impulse);
        }
    }*/

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        Debug.Log(isjumping);
        anim.SetBool("isJumping", isjumping);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigid.linearVelocity.y < 0)
        {
            Debug.DrawRay(transform.position, Vector2.down * 0.5f, new Color(1, 0, 0, 0.7f));

            ray = Physics2D.Raycast(transform.position, Vector2.down,
            0.5f, LayerMask.GetMask("Platform"));
            if (ray.collider != null)
            {
                if (ray.collider.gameObject.layer == 10)
                {
                    isjumping = false;
                }

            }
        }

        if(rigid.linearVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rigid.linearVelocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
            
    }
}
