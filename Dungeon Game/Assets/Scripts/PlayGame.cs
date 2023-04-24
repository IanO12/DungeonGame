using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
    public void Play(){
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("StartingLevel 1");
    }

    public void Resume(){
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("StartingLevel 1");
    }
}
