using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public int damage;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        Destroy(gameObject);
    }
    private void Awake()
    {
        this.gameObject.transform.rotation = FindObjectOfType<PlayerMovement>().transform.rotation;
    }
    private void FixedUpdate()
    {
        this.gameObject.transform.position += transform.right * speed;
    }
}