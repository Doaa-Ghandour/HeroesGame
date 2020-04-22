using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreparingController : MonoBehaviour
{
    public SpriteRenderer guide;
    public Sprite[] guideSprite;
    public GameObject[] buttons;
    public AudioSource guideSource;
    public AudioClip[] guideClip;
    public float stepNo;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
        stepNo = 0.0f;
        guide.sprite = guideSprite[0];
        guideSource.clip = guideClip[0];
        guideSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        mask.fillAmount = stepNo / 6;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void FirstStep()
    {
        stepNo++;
        guide.sprite = guideSprite[1];
        guideSource.clip = guideClip[1];
        guideSource.Play();
        buttons[0].SetActive(true);
    }

    public void SecondStep()
    {
        stepNo++;
        guide.sprite = guideSprite[2];
        guideSource.clip = guideClip[2];
        guideSource.Play();
        buttons[1].SetActive(true);
    }

    public void ThirdStep()
    {
        stepNo++;
        guide.sprite = guideSprite[3];
        guideSource.clip = guideClip[3];
        guideSource.Play();
        buttons[2].SetActive(true);
    }

    public void FourthStep()
    {
        stepNo++;
        guide.sprite = guideSprite[4];
        guideSource.clip = guideClip[4];
        guideSource.Play();
        buttons[3].SetActive(true);
    }

    public void FifthStep()
    {
        stepNo++;
        guide.sprite = guideSprite[5];
        guideSource.clip = guideClip[5];
        guideSource.Play();
        buttons[4].SetActive(true);
    }

    public void SixthStep()
    {
        stepNo++;
        guide.sprite = guideSprite[7];
        guideSource.clip = guideClip[7];
        guideSource.Play();
        buttons[5].SetActive(true);
    }

    public void Play()
    {
        if (PlayerPrefs.GetInt("ChosenLevel") == 1) {
            SceneManager.LoadScene("FirstLevel");
        }
        else if (PlayerPrefs.GetInt("ChosenLevel") == 2)
        {
            SceneManager.LoadScene("SecondLevel");
        }
        else if (PlayerPrefs.GetInt("ChosenLevel") == 3)
        {
            SceneManager.LoadScene("ThirdLevel");
        }
    }
}
