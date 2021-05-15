using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AsyncOperation _asyncOperation;

    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        var objectsList = FindObjectsOfType(this.GetType());
        if (objectsList.Length > 1)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {

    }

    public void LoadNextLevel()
    {
        SetTimeScaleToNormal();

        if (_asyncOperation == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            int nextScene = currentScene.buildIndex + 1;

            if (nextScene >= SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }

            if ((_asyncOperation = SceneManager.LoadSceneAsync(nextScene)) != null)
            {
                _asyncOperation.allowSceneActivation = true;
            }
        }
    }

    public void SetTimeScaleToNormal()
    {
        Time.timeScale = 1.0f;
    }
}
