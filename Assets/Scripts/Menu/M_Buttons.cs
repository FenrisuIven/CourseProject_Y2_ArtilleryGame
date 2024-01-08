using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Menu : MonoBehaviour
{
    public void OnPlayButton() => SceneManager.LoadScene(1);
    public void OnQuitButton() => Application.Quit();
}
