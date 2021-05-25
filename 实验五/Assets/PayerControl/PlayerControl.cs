using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D heroBody;
    public float force = 100;
    public float jumpForce = 500;
    float fInput = 0.0f;
    public float MaxSpeed = 5;
    [HideInInspector]
    public bool bFaceRight=true;
    //[SerializeField]
    private bool bGrounded = false;
    Transform mGroundCheck;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        heroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fInput = Input.GetAxis("Horizontal");
        if(fInput<0&&bFaceRight)
        {
            flip();
        }
        else if(fInput > 0 && !bFaceRight)
                {
            flip();
        }
        //heroBody.AddForce(Vector2.right * h * force);

        bGrounded = Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //if(heroBody.velocity.x>0.1)
        {
            anim.SetFloat("speed", Mathf.Abs(heroBody.velocity.x));//走的动画
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(heroBody.velocity.x) < MaxSpeed)
            heroBody.AddForce(fInput * force * Vector2.right);

        if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
            heroBody.velocity = new Vector2(Mathf.Sign(heroBody.velocity.x) * MaxSpeed, heroBody.velocity.y);
        bool bjump = false;
        if(bGrounded)
        {
            bjump = Input.GetKeyDown(KeyCode.Space);
            Vector2 upForce = new Vector2(0, 1);
            if (bjump)
            {
                heroBody.AddForce(upForce * jumpForce);
                anim.SetTrigger("Jump");//如果跳就触发跳的帧动画
            }
            
        }
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        bFaceRight = !bFaceRight;
    }
    
}
