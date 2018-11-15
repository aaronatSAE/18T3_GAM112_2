using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource menuMusic;

    private void Start()
    {
        if(gameObject.name == "EGO MenuManager")
        {
            menuMusic = menuMusic.GetComponent<AudioSource>();
            menuMusic.Play();
        }
        

    }

    public void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
