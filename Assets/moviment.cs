using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviment : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    Vector2 movement;
    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        movement.Normalize();
        rb.velocity=new Vector2(movement.x*speed*Time.fixedDeltaTime,movement.y*speed*Time.fixedDeltaTime);
    }
}
