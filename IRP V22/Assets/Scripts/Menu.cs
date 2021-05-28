///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            Menu.cs
///     Author:          Jack Peedle
///     Date Created:    22/01/2021
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Quit game
    public void QuitGame()
    {
        // Quit
        Application.Quit();
    }

    // Start game
    public void StartGame()
    {
        // Load game scene
        SceneManager.LoadScene("GameScene");
    }

}
