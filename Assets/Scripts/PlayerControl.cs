using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveForce = 400f;
    public float maxSpeed = 5f;
    public float jumpForce = 100f;
    private Animator anim;
    [HideInInspector]
    public bool jump = false;

    private bool grounded = false;
    private Transform groundCheck;

    private Rigidbody2D heroBody;
    [HideInInspector]
    public bool faceRight = true;

    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        //BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        //获取水平方向输入
        float h = Input.GetAxis("Horizontal");
        //判断是否超过最大速度
        if (h * heroBody.velocity.x < maxSpeed)
            // heroBody.AddForce(Vector2.right * h * moveForce);
            heroBody.velocity += Vector2.right * h * moveForce;
        if (Mathf.Abs(heroBody.velocity.x) > maxSpeed)
            //heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * h * maxSpeed, heroBody.velocity.y);
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * maxSpeed, heroBody.velocity.y);
        // anim.SetFloat("speed", Mathf.Abs(h));
        anim.SetFloat("speed", Mathf.Abs(heroBody.velocity.x));
        if (h > 0 && !faceRight)
        {
            flip();
        }
        if (h < 0 && faceRight)
        {
            flip();
        }
        if (jump)
        {
            anim.SetTrigger("jump");
            heroBody.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 
                                           1 << LayerMask.NameToLayer("Ground"));
        if(Input.GetButtonDown("Jump")&& grounded)
        {
            jump = true;
        }
    }

    void flip()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
