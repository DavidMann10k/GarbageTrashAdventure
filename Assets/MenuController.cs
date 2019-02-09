using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject playModeSelectionMenu = null;

    [SerializeField]
    GameObject sceneSelectionMenu = null;

    [SerializeField]
    GameObject gameSelectionMenu = null;


    public void ChangeToSceneSelectionMenu()
    {
        playModeSelectionMenu.SetActive(false);
        gameSelectionMenu.SetActive(false);

        sceneSelectionMenu.SetActive(true);
    }

    public void ChangeToPlayModeSelectionMenu()
    {
        sceneSelectionMenu.SetActive(false);
        gameSelectionMenu.SetActive(false);

        playModeSelectionMenu.SetActive(true);
    }

    public void ChangeToGameSelectionMenu()
    {
        sceneSelectionMenu.SetActive(false);
        playModeSelectionMenu.SetActive(false);

        gameSelectionMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
