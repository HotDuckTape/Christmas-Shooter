using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class SwitchCamChannel : MonoBehaviour
{
    CinemachineBrain cinemachineCam;
    [SerializeField] CinemachineInputAxisController controller;
    public int playerIndexCount = 2;
    void Awake()
    {
        Debug.Log("performed");       
    }

    //public void OnPlayerJoined()
    //{

    //}

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log(cinemachineCam);
        cinemachineCam.ChannelMask = (OutputChannels)(playerIndexCount);
        Debug.Log(cinemachineCam.ChannelMask);
    }
    public void ChangeChannel(int playerIndex, CinemachineBrain brain, CinemachineCamera vCam)
    {
        controller.PlayerIndex = playerIndex;
        //Debug.Log(playerIndexCount + " " + (1 << playerIndexCount));
        Debug.Log("brain var : " + brain);
        brain.ChannelMask = (OutputChannels)(1 << playerIndex);
        vCam.OutputChannel = (OutputChannels)(1 << playerIndex);
        //Debug.Log("CHANNELMASK: " + cinemachineCam.ChannelMask);
    }
}

