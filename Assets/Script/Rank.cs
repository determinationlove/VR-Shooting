using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using LSFile;
using VR_Shooting_Path;

public class Rank : MonoBehaviour
{
    public pathFile csvTool;
    public VR_Shooting_Path.Path path;
    public List<string> rank;
    public int newScore;
    public Text rankScore;
    public Button again;

    public void Rank_Start()
    {
        Init();

        rank = csvTool.Load(path.RankData);
        rank.Add(newScore.ToString());
        reRank();
    }

    public void Init()
    {
        rank = new List<string>();
        path = new VR_Shooting_Path.Path();
        csvTool = new pathFile(path.RankData, "ScoreRank", "得分");
    }

    public void reRank()
    {
        rank = BubbleSort(rank);
        csvTool.Save(rank, path.DataPath, "");

        string all = "";
        for (int i = 0; i < rank.Count; i++)
        {
            if (i == rank.Count - 1)
            {
                all += rank[i];
                continue;
            }

            all += rank[i] + "\n";
        }

        rankScore.text = all;
    }

    private List<string> BubbleSort(List<string> _list)
    {
        var temp = 0;

        for (int i = 1; i < _list.Count; i++)
        {
            for (int j = 1; j < _list.Count - 0 - i; j++)
            {
                if (int.Parse(_list[j]) < int.Parse(_list[j + 1]))
                {
                    temp = int.Parse(_list[j]);
                    _list[j] = _list[j + 1];
                    _list[j + 1] = temp.ToString();
                }
            }
        }

        List<string> newList = new List<string>();

        for (int i = 0; i < 7; i++)
        {
            newList.Add(_list[i]);
        }

        return newList;
    }


}
