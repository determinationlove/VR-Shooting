using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldScore : MonoBehaviour
{
    public int total;
    public Text text;

    public void Update()
    {
        text.text = total.ToString();
    }
}
