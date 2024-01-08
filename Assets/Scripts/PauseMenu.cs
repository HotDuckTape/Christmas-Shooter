using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode escapeKey = KeyCode.Escape;
    public bool _PauseMenuActive;

    [SerializeField] private Canvas _pauseScreen;

    private void Start()
    {
        _pauseScreen.enabled = false;
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(escapeKey))
            _PauseMenuActive = !_PauseMenuActive;

        if (_PauseMenuActive)
            PauseGame();
        else
            ResumeGame();
    }

    private void PauseGame()
    {
        _pauseScreen.enabled = true;
        // No Input
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        _pauseScreen.enabled = false;
        _PauseMenuActive = false;
        // Yes Input
        Time.timeScale = 1;
    }
}