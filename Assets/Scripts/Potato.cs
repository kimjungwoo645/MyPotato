using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    Rigidbody2D rb;
    bool isDead;

    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject sprite;
    [SerializeField] FlashImage flashImage;

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") )
        {
            if (!isDead && rb.isKinematic == false)
            {
                rb.velocity = new Vector2(0.0f, jumpVelocity);
            }
        }
        else if (Input.GetButtonDown("Fire2") && transform.position.y > maxHeight)
        {
            if (!isDead && rb.isKinematic == false)
            {
                rb.velocity = new Vector2(0.0f, -jumpVelocity);
            }    
        }
        //감자회전
        float angle;
        if (isDead)
        {
            angle = -90.0f;
        }
        else
        {
            angle = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg;
        }

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead == false)
        {
            Camera.main.SendMessage("Shake", SendMessageOptions.DontRequireReceiver);
        }
        flashImage.StartFlash();
        isDead = true;
    }
    public void SetKinematic(bool value)
    {
        rb.isKinematic = value;
    }
    public void LeftButton()
    {
        if (!isDead && rb.isKinematic == false)
            {
                rb.velocity = new Vector2(0.0f, jumpVelocity);
            }
    }
    public void RightButton()
    {
         if (!isDead && rb.isKinematic == false)
            {
                rb.velocity = new Vector2(0.0f, -jumpVelocity);
            }  
    }
}
