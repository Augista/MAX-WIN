using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void PlayGameBtn(string PlayGame)
    {
        SceneManager.LoadScene(PlayGame);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
