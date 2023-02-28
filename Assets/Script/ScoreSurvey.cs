using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreSurvey : MonoBehaviour
{
    public bool survey;
    public bool surveyEnd;
    public bool testing = false;
    public int defaultValue = 4; // 預設值
    public Button[] buttons; // 所有按鈕
    public int selectedButtonIndex; // 目前選擇的按鈕索引


    public void ScoreSurvey_Start()
    {
        selectedButtonIndex = defaultValue - 1;
        buttons[selectedButtonIndex].Select();
    }

    public void ScoreSurvey_Update()
    {
        if (survey == false)
            return;

        if (testing)
            Test_Select();
        else
            VR_Select();

        Next();
    }

    public void VR_Select()
    {
        float verticalInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;

        if (verticalInput > 0.5f) // 推上
        {
            // 選擇上一個按鈕
            selectedButtonIndex -= 1;
            if (selectedButtonIndex < 0)
            {
                selectedButtonIndex = buttons.Length - 1;
                buttons[selectedButtonIndex].Select();
            }

        }
        else if (verticalInput < -0.5f) // 推下
        {
            // 選擇下一個按鈕
            selectedButtonIndex += 1;
            if (selectedButtonIndex >= buttons.Length)
            {
                selectedButtonIndex = 0;
                buttons[selectedButtonIndex].Select();
            }
        }
    }

    public void Test_Select()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // 推上
        {
            // 選擇上一個按鈕
            selectedButtonIndex -= 1;

            if (selectedButtonIndex < 0)
            {
                selectedButtonIndex = buttons.Length - 1;
                buttons[selectedButtonIndex].Select();
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) // 推下
        {
            // 選擇下一個按鈕
            selectedButtonIndex += 1;

            if (selectedButtonIndex >= buttons.Length)
            {
                selectedButtonIndex = 0;
                buttons[selectedButtonIndex].Select();
            }
        }
    }

    void Next()
    {
        if (testing)
            if (Input.GetKeyDown(KeyCode.Return))
            {
                survey = false;
                surveyEnd = true;
            }
        else
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                survey = false;
                surveyEnd = true;
                EventSystem.current.SetSelectedGameObject(null);
            }
    }
}
