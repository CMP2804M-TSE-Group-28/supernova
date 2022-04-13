using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//me love elden ring
public class Menu : MonoBehaviour
{
    [SerializeField] private int LoadedScene;

    public void LoadScene()
    {
        SceneManager.LoadScene(LoadedScene);
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
