using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    public int myBuilder;

    public int score;
    public WorldScore worldScore;

    void Start()
    {
        getInfo();
    }

    void Update()
    {
        if (gameManager.ready == false)
            Destroy(transform.parent.gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<BoxCollider>().enabled = false;

        gameManager.Instant_Replenish(myBuilder);
        worldScore.total += score * (myBuilder + 1);
        print("準確分數 " + score + " 與 距離加權 " + (myBuilder + 1) + " 倍率，總共 " + score * (myBuilder + 1));

        Destroy(transform.parent.gameObject);
    }

    public void getInfo()
    {
        gameManager = transform.parent.GetComponent<Target>().gameManager;
        myBuilder = transform.parent.GetComponent<Target>().myBuilder;
        worldScore = transform.parent.GetComponent<Target>().worldScore;
    }
}
