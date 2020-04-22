using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ResultPopUp : MonoBehaviour
{
    public AudioSource popUpSource;
    public AudioClip successClip, loseClip;

    void OnEnable()
    {
        Debug.Log(PlayerPrefs.GetInt("Win"));
        if (PlayerPrefs.GetInt("Win") == 1)
        {
            popUpSource.clip = successClip;
            popUpSource.Play();
        }
        else if (PlayerPrefs.GetInt("Win") == 0)
        {
            popUpSource.clip = loseClip;
            popUpSource.Play();

        }
            
    }

    public void PlayAgain()
    {
        if (PlayerPrefs.GetInt("Win") == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("Preparing");

        }
            
    }

    public void BackToProtection()
    {
        SceneManager.LoadScene("GamesScene");
    }
}
