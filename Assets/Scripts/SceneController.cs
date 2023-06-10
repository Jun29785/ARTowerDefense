using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        SceneLoad("Lobby");
    }

    public void SceneLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
