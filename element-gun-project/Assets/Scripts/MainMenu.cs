using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private string outputMenu = "MainScene";
    [SerializeField] public AudioSource audioSource;   
    private float musicVolume = 1f;
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogFormat("Volume {0} Volume Mixer {1}",audioSource.volume,musicVolume);
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
        
    }
    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale =1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale =0f;
        GameIsPaused = true;
    }
    public void PlayGame()
    {
        //SceneManager.LoadScene(outputMenu);
        Time.timeScale =1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
        audioSource.volume = musicVolume;
    }
}
