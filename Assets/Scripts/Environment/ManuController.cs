using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManuController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        WinDisable();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SetScene(int sceneNumber)
    {
        GameManager.sceneNow = sceneNumber;
    }
    public void NextLevel()
    {
        GameManager.sceneNow += 1;
        string scene = "Level0" + GameManager.sceneNow;
        SceneManager.LoadScene(scene);
        WinDisable();
    }
    public void Reload()
    {
        string scene = "Level0" + GameManager.sceneNow;
        SceneManager.LoadScene(scene);
        WinDisable();

    }
    public void ResetGame()
    {
        GameManager.ResetHearth();
        GameManager.SceneLockReset();
        CoinsManager.CoinReset();
    }
    void WinDisable()
    {
        GameManager.win = false;
       
    }
  
}
