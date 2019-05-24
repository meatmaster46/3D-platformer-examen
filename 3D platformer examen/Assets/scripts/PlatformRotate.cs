using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
    }
}
