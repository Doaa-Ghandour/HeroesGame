using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public AudioSource introSource;
    public AudioClip introClip;

    void Start()
    {
        introSource.clip = introClip;
        introSource.Play();
        PlayerPrefs.SetInt("Win", 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        introSource.Stop();
    }
}
