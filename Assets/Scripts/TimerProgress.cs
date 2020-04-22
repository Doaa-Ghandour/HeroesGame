using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class TimerProgress : MonoBehaviour
{
    public Image mask;
    public Image shield;
    public Sprite redBar;
    public Sprite destroyedShield;
    public Text timeText;
    public GameObject popUp;
    public Sprite losePopUp;
    public AudioSource popUpSource;
    public AudioClip popUpClip;
    public Draging instance;

    private float timeLimit = 20f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Timer");
        if(timeLimit <= 0 && !instance.done)
        {
            timeLimit = 0;
            PlayerPrefs.SetInt("Win", 0);
            shield.sprite = destroyedShield;
            popUp.SetActive(true);
            popUp.GetComponent<SpriteRenderer>().sprite = losePopUp;
        }
    }

    IEnumerator Timer()
    {
        if (!instance.done)
        {
            yield return new WaitForSeconds(2f);
            timeLimit -= Time.deltaTime;
            timeText.text = "" + (int)timeLimit;
            mask.fillAmount = timeLimit / 20;
            if (timeLimit < 6)
            {
                mask.sprite = redBar;
            }
        }
        else
        {
            Debug.Log("DONE!");
        }
    }
}
