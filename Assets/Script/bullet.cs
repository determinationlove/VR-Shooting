using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Transform Pool;

    public void Start()
    {
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.SetParent(Pool);
    }

    public void Update()
    {
        if (transform.position != Pool.position)
        {
            Invoke("Retrun", 5f);
        }
    }

    void Retrun()
    {
        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.position = Pool.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<BoxCollider>().enabled = false;
    }

    void OnCollisionEnter(Collision other)
    {
        transform.GetComponent<BoxCollider>().enabled = false;
    }
}
