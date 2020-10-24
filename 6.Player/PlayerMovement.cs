using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool crStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    public void Movement()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        if(Input.GetAxis("Horizontal")>0)
        {
            if (rb.velocity.x < 5)
                rb.AddForce(10*Vector2.right,ForceMode2D.Force);
        }
        else if(Input.GetAxis("Horizontal")<0)
        {
            if (rb.velocity.x > -5)
                rb.AddForce(10*Vector2.left,ForceMode2D.Force);
        }
        
    }
    public void Jump()
    {
        if(Input.GetAxis("Vertical") > 0)
                {
                    if (!crStarted)
                        StartCoroutine(JumpingTimeout());
                }
    }

    IEnumerator JumpingTimeout()
    {
        crStarted = true;
        rb.AddForce(10 * Vector2.up, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2);
        crStarted = false;
    }
}
