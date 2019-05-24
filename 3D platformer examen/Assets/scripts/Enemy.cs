using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //movement
    public float speed;
    public Transform edgeCheck;
    public bool seesPlayer = true;
    public float rayLength;
    public float knockBack;
    //stats
    public int health;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Time.timeScale == 1)
        {//Debug.DrawRay(transform.position, Vector3.down, Color.red, 1.4f);
            RaycastHit hit;
            if (Physics.Raycast(edgeCheck.transform.position, Vector3.down, out hit, rayLength))
            {
                this.gameObject.transform.position += transform.right * speed;
            }

            else
            {
                transform.Rotate(new Vector3(0, -180, 0));
            }
            //Debug.DrawRay(edgeCheck.transform.position, Vector3.down , Color.red ,rayLength);
            //if (Physics.Raycast(this.transform.position, ))

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.transform.position - this.transform.position * knockBack);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
