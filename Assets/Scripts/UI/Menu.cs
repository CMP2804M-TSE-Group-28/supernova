using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// VANTA - created to change scene in main menu
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
