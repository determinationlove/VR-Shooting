using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameSet ThisGameSet;
    public List<int> Builder;
    public List<Transform> BuildPoint;
    public WorldScore worldScore;

    int col = 0;
    int extra = 0;
    public GameObject temp;
    public bool ready;
    public bool gameover;

    public Text end;
    public float startTime;
    public float endTime;

    public void Init()
    {
        
        ThisGameSet = new GameSet();
        Builder.Clear();
        BuildPoint.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            BuildPoint.Add(transform.GetChild(i));
        }

        startTime = Time.time;
    }

    public void GameManager_Start()
    {
        col = (int)ThisGameSet.Num / 10;
        extra = (int)ThisGameSet.Num % 10;

        for (int i = 0; i < col; i++)
        {
            Builder.Add(10);
        }

        if (ThisGameSet.Num % 10 != 0)
            Builder.Add(extra);
    }

    void Update()
    {
        if (ready == false)
            return;
        Gameing();
    }

    public void Gameing()
    {
        for (int i = 0; i < Builder.Count; i++)
        {
            if (Builder[i] >= 1)
                return;
        }

        if(Time.time - endTime < 5)
            end.text = "遊戲將於 " + (int)((5.1) - (Time.time - endTime)) + " 秒後結束";

        if(Time.time - endTime > 5)
        {
            ready = false;
            gameover = true;
            end.text = "";
        }
            
    }

    public void Init_Instant()
    {
        for (int i = 0; i < col; i++)
        {
            temp = GameObject.Instantiate(
                Resources.Load<GameObject>("靶子"), BuildPoint[i].position, Quaternion.identity
            );
            temp.transform.SetParent(BuildPoint[i]);
            temp.GetComponent<Target>().gameManager = this;
            temp.GetComponent<Target>().myBuilder = i;
            temp.GetComponent<Target>().Drift();
            Builder[i] -= 1;
        }

        if (extra != 0)
            for (int i = 0; i < 1; i++)
            {
                temp = GameObject.Instantiate(
                    Resources.Load<GameObject>("靶子"), BuildPoint[col].position, Quaternion.identity
                );
                temp.transform.SetParent(BuildPoint[col]);
                temp.GetComponent<Target>().gameManager = this;
                temp.GetComponent<Target>().myBuilder = col;
                temp.GetComponent<Target>().Drift();
                Builder[col] -= 1;
            }
    }

    public void Instant_Replenish(int BuilderID)
    {
        endTime = Time.time;
        Builder[BuilderID] -= 1;

        if (Builder[BuilderID] <= 0)
            return;

        temp = GameObject.Instantiate(
                Resources.Load<GameObject>("靶子"), BuildPoint[BuilderID].position, Quaternion.identity
            );
        temp.transform.SetParent(BuildPoint[BuilderID]);
        temp.GetComponent<Target>().gameManager = this;
        temp.GetComponent<Target>().myBuilder = BuilderID;
        temp.GetComponent<Target>().Drift();
    }

    public void Run()
    {

    }

    public void Stop()
    {

    }
}
