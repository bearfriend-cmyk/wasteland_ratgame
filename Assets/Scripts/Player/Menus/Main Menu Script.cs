using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Scene playScene;
    public TextMeshProUGUI controls_gui;
    private bool controls_Shown = false;
    public void OnStartClick()
    {
        SceneManager.LoadScene("Purpe_Rodent");  
    }

    public void OnExitClick()
    {

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;

#endif
        Application.Quit();
    }

    public void OnControlsClick()
    {
        controls_Shown = !controls_Shown;

        if (controls_Shown)
        { controls_gui.text = "[WASD - Movement]    [SPACE - Attack]"; }
        else
        { controls_gui.text = ""; }

    }

}
