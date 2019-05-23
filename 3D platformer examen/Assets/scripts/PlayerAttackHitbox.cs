using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public int damage;

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.GetComponent<Enemy>())
    //    {
    //        collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
    //        Debug.Log("hit");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("hit");
        }
    }
}
