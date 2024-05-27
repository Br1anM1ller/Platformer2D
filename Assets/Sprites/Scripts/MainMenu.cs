using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelMenuCanvas;

    public void PlayButton()
    {
        levelMenuCanvas.SetActive(true);
    }
}
