using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private float moveSpeed = 7f;
    private float jumpforce = 14f;
    private float dirX = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpforce , 0); 
        }

        playerAnimation();
    }

    private void playerAnimation()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }

        else
        {
            anim.SetBool("running", false);
        }
    }
}
