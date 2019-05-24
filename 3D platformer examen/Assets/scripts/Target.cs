using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameObject gameManager;
    public AudioClip destroyed;

    private void Start()
    {
        FindObjectOfType<GameManager>().targets.Add(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerAttackHitbox>() || other.gameObject.GetComponent<PlayerBullet>())
        {
            AudioSource.PlayClipAtPoint(destroyed, transform.position);
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().targets.Remove(this.gameObject);
        }
    }
}
