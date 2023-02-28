using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace VR_Shooting_Path
{
    public class Path
    {
        public string DataPath = System.IO.Path.Combine(Application.dataPath, "Script/");
        public string RankData = System.IO.Path.Combine(Application.dataPath, "Script", "ScoreRank.csv");
    }
}
