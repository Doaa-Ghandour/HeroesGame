using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public Image level1Image, level2Image, level3Image;
    public Sprite shinyShield;
    public AudioSource levelSource;
    public AudioClip levelClip;


    private void Start()
    {
        levelSource.clip = levelClip;
        levelSource.Play();
        PlayerPrefs.SetInt("ChosenLevel", 0);

        if (PlayerPrefs.GetInt("Win") == 1 & PlayerPrefs.GetInt("Level") == 1)
        {
            level1Image.sprite = shinyShield;
        }
        if (PlayerPrefs.GetInt("Win") == 1 & PlayerPrefs.GetInt("Level") == 2)
        {
            level2Image.sprite = shinyShield;
        }
        if (PlayerPrefs.GetInt("Win") == 1 & PlayerPrefs.GetInt("Level") == 3)
        {
            level3Image.sprite = shinyShield;
        }
    }

    public void FirstLevel()
    {
        PlayerPrefs.SetInt("ChosenLevel", 1);

        if (PlayerPrefs.GetInt("Win") == 1)
        {
            SceneManager.LoadScene("FirstLevel");
        }
        else
        {
            SceneManager.LoadScene("Preparing");
        }       
    }

    public void SecondLevel()
    {
        PlayerPrefs.SetInt("ChosenLevel", 2);

        if (PlayerPrefs.GetInt("Win") == 1)
        {
            SceneManager.LoadScene("SecondLevel");
        }
        else
        {
            SceneManager.LoadScene("Preparing");
        }
    }

    public void ThirdLevel()
    {
        PlayerPrefs.SetInt("ChosenLevel", 3);

        if (PlayerPrefs.GetInt("Win") == 1)
        {
            SceneManager.LoadScene("ThirdLevel");
        }
        else
        {
            SceneManager.LoadScene("Preparing");
        }
    }
}
