using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenControls : MonoBehaviour
{
    [SerializeField] private GameObject image;

    public void Click()
    {
        image.SetActive(!image.activeSelf);
    }
}
