using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
