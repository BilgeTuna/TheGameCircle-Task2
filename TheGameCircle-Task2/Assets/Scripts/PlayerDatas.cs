using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDatas
{
    public static int Score
    {
        get
        {
            return PlayerPrefs.GetInt("scoreKey", 0);
        }
        set
        {
            PlayerPrefs.SetInt("scoreKey", value);
        }
    }

}
