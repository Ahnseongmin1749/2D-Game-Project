using UnityEngine;

public class Player_Platformer : MonoBehaviour
{
    Rigidbody2D rigid;
    float move;
    public float speed;
    public float jump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal");

        rigid.linearVelocity = new Vector2(move * speed, rigid.linearVelocity.y);
    }
}
