using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreenManager : MonoBehaviour
{
    public void ExitGame()
    {
        print("QUIT");
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GlobalClass.DistanceTraveled = 0;
    }
}
