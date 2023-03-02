using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public List<GameObject> bullet;
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform Pool;
    public GameObject tempObj;
    public int id = 0;

    public void Start()
    {
        ObjPool();
    }

    void ObjPool()
    {
        for (int i = 0; i < 200; i++)
        {
            GameObject temp = GameObject.Instantiate(
                Resources.Load<GameObject>("Cube"), Pool.position, Quaternion.identity
            );
            temp.GetComponent<bullet>().Pool = Pool;
            bullet.Add(temp);
        }
    }

    void Update()
    {
        if (id >= 200)
            id = 0;

        /*
        if (Input.GetKeyDown(KeyCode.Z))
        {
            tempObj = bullet[id];
            id++;
            tempObj.transform.position = transform.position;
            tempObj.transform.GetComponent<BoxCollider>().enabled = true;
            tempObj.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        }
        */
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            tempObj = bullet[id];
            id++;
            tempObj.transform.position = FirePoint1.position;
            tempObj.transform.GetComponent<BoxCollider>().enabled = true;
            tempObj.GetComponent<Rigidbody>().AddForce(FirePoint1.forward * 1200);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            tempObj = bullet[id];
            id++;
            tempObj.transform.position = FirePoint2.position;
            tempObj.transform.GetComponent<BoxCollider>().enabled = true;
            tempObj.GetComponent<Rigidbody>().AddForce(FirePoint2.forward * 1200);
        }
        
    }

    
}
