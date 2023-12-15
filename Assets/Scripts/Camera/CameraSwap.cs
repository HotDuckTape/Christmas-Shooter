using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState
{
    alive,
    dead,
    startCutscene,
}
public class CameraSwap : MonoBehaviour
{
    public GameObject[] cams;
    public PlayerState pState;
    public bool startCutScene;
    public bool playerDead;
    //[SerializeField] private Car _car;

    private void Update()
    {
        
        switch (pState)
        {
            case PlayerState.alive:
                startCutScene = false;
                cams[0].SetActive(true);
                break;
            case PlayerState.dead:
                playerDead = true;
                cams[0].SetActive(false);
                cams[1].SetActive(true);
                break;
            case PlayerState.startCutscene:
                startCutScene = true;
                cams[0].SetActive(false);
                cams[1].SetActive(false);
                cams[2].SetActive(true);
                break;
            default:
                break;
        }
    }
}
