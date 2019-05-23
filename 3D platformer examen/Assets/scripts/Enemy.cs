using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //movement
    public float speed;
    public Transform edgeCheck;
    public bool seesPlayer = true;
    //stats
    public int health;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Time.timeScale == 1)
        {
            RaycastHit hit;
            if (Physics.Raycast(edgeCheck.transform.position, transform.up * -1, out hit))
            {
                this.gameObject.transform.position += transform.right * speed;
            }
            else
            {
                transform.Rotate(new Vector3(0, -180, 0));
            }
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
