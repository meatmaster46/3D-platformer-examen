using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //walking
    private float speed;
    public float walkSpeed;
    public float runSpeed;

    //jumping
    public GameObject groundHitbox;
    public Transform groundcheck;
    public Vector3 groundcheckSize;
    public float jumpForce;
    public bool grounded = false;
    public bool doubleJump = true;

    //attacking
    public GameObject attackHitbox;
    public bool attacking = false;

    public float dashforce;
    public float attackCooldown;
    public float attackCooldownTime;
    public bool attackActive = true;
    public ParticleSystem rechargeParticle;
    public GameObject attackPoint;

    public GameObject bullet;

    private Rigidbody rb;

    void Start()
    {
        speed = walkSpeed;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //this.transform.rotation = Quaternion.LookRotation(rb.velocity);
        if (attackCooldownTime > 0)
        {
            attackCooldownTime -= Time.deltaTime;
        }
        if (attackCooldownTime <= 0)
        {
            attackActive = true;
            rechargeParticle.Play();
            Invoke("ParticleStop", 0.1f);
        }


        if (attacking == false)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime;
            this.gameObject.transform.position += movement * speed;
            if (movement.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0f, 0);
            }
            if (movement.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            if (Input.GetKey("left shift"))
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && grounded == true)
        {
            Jump();
        }
        if (Input.GetKeyDown("space") && grounded == false && doubleJump == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            Jump();
            doubleJump = false;
        }
        if (grounded == true)
            doubleJump = true;

        if (Input.GetKeyDown("z") && attacking == false && attackActive == true)
        {
            Attack();
        }
        if (Input.GetKeyDown("x") && attacking == false)
        {
            Instantiate(bullet, attackPoint.transform.position, Quaternion.identity);
        }
    }

    void Attack()
    {
        rb.velocity = new Vector3(0,0,0);
        rb.useGravity = false;
        attacking = true;
        Invoke("AttackStart", 0.2f);
    }
    void AttackStart()
    {
        if (Input.GetKey("up"))
            rb.AddForce(0, dashforce, 0);
        if (Input.GetKey("down"))
            rb.AddForce(0, -dashforce * 1.2f, 0);
        if (Input.GetKey("right"))
            rb.AddForce(dashforce, 0, 0);
        if (Input.GetKey("left"))
            rb.AddForce(-dashforce, 0, 0);
        attackHitbox.gameObject.SetActive(true);
        Invoke("AttackEnd", 0.45f);
    }
    void AttackEnd()
    {
        rb.useGravity = true;
        rb.velocity = new Vector3(0, 0, 0);
        attackHitbox.gameObject.SetActive(false);
        attacking = false;
        attackActive = false;
        attackCooldownTime = attackCooldown;
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
    void ParticleStop()
    {
        rechargeParticle.Stop();
    }
}