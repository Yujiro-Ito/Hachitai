using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData
{
    private static ScoreData _singleton;
    public static ScoreData Instance
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = new ScoreData();
            }
            return _singleton;
        }
    }

    public float Score;
}