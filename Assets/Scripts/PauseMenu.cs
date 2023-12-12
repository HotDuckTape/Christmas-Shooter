using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode escapeKey = KeyCode.Escape;
    public bool PauseMenuActive;
    [SerializeField] private Canvas pauseScreen;

    private void Start()
    {
        pauseScreen.enabled = false;
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(escapeKey))
            PauseMenuActive = !PauseMenuActive;

        if (PauseMenuActive)
            PauseGame();
        else
            ResumeGame();
    }

    private void PauseGame()
    {
        pauseScreen.enabled = true;
        // No Input
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        pauseScreen.enabled = false;
        PauseMenuActive = false;
        // Yes Input
        Time.timeScale = 1;
    }
}