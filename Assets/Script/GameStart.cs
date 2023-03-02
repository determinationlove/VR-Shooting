using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Text num;
    public Text speed;
    public Button startgame;

    public GameObject OVRcontrol;

    void Start()
    {

    }

    void Update()
    {
        num.text = slider1.value.ToString();

        switch (slider2.value)
        {
            case 1:
                speed.text = "慢";
                break;
            case 2:
                speed.text = "普通";
                break;
            case 3:
                speed.text = "快";
                break;
            case 4:
                speed.text = "星爆級";
                break;
        }
    }
}

public class GameSet
{
    public float Num;
    public float Speed;
}
