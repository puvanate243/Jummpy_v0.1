using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool lSound;
    public static int hearthOrigin = PlayerPrefs.GetInt("hearthOrigin", 3);
    public static int hearth;
    public static int secondsCount;
    public static bool win=false;
    public static int sceneNow;
    public static int sceneLock = PlayerPrefs.GetInt("sceneLock", sceneLock);
    public static int TxtCount;
    
     void Start()
    {
        lSound = true;
        PlayerPrefs.SetInt("hearthOrigin", hearthOrigin);
     
    }
    public static void AddSceneLock(int temp)
    {
            PlayerPrefs.SetInt("sceneLock", temp);
    }
    public static void SceneLockReset()
    {
        sceneLock = 0;
        PlayerPrefs.SetInt("sceneLock", sceneLock);
    }
    public static void AddHearth(int h)
    {
        PlayerPrefs.SetInt("hearthOrigin", h);
        hearthOrigin = PlayerPrefs.GetInt("hearthOrigin", h);
    }
    public static void ResetHearth()
    {
        PlayerPrefs.SetInt("hearthOrigin", 3);
        hearthOrigin = PlayerPrefs.GetInt("hearthOrigin", 3);
    }
}
