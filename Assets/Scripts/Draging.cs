using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Draging : MonoBehaviour
{
    public GameObject virusPrefab;
    public GameObject explosion;
    public GameObject spry;
    public SpriteRenderer inviroment;
    public Sprite cleanInviroment;
    public GameObject popUp;
    public Sprite winningPopUp, losePopUp;
    public int level;
    public int virusNo;
    public bool done;
    //public AudioSource popUpSource;
    //public AudioClip popUpClip;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 randomPos;
    private bool doneSpawning;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnVirus());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        StartCoroutine(CheckFinished());
    }

    void OnMouseDown()
    {
        spry.SetActive(true);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    private void OnMouseUp()
    {
        spry.SetActive(false);
    }


    //Check the answers
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "virus")
        {
            GameObject vir = col.gameObject;
            Destroy(vir);
            GameObject exp = Instantiate(explosion, vir.transform.position, Quaternion.identity);
            Destroy(exp.gameObject, 0.3f);
            counter++;
        } 
        else
        {
            Debug.Log("pass");
        }
    }

    IEnumerator SpawnVirus()
    {
        switch (level)
        {
            case 1:
                for (int i = 0; i < virusNo; i++)
                {
                    yield return new WaitForSeconds(1.5f);
                    randomPos = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-4.0f, 1.5f), 0.0f);
                    GameObject virus = Instantiate(virusPrefab, randomPos, Quaternion.identity);
                    virus.transform.localScale = Vector3.one * Random.Range(0.5f, 0.8f);
                }
                doneSpawning = true;
                break;

            case 2:
                for (int i = 0; i < virusNo; i++)
                {
                    yield return new WaitForSeconds(1.0f);
                    randomPos = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-4.0f, 4.0f), 0.0f);
                    GameObject virus = Instantiate(virusPrefab, randomPos, Quaternion.identity);
                    virus.transform.localScale = Vector3.one * Random.Range(0.5f, 0.8f);
                }
                doneSpawning = true;
                break;

            case 3:
                for (int i = 0; i < virusNo; i++)
                {
                    yield return new WaitForSeconds(0.5f);
                    randomPos = new Vector3(Random.Range(-7.0f, 7.0f), Random.Range(-4.0f, 4.0f), 0.0f);
                    GameObject virus = Instantiate(virusPrefab, randomPos, Quaternion.identity);
                    virus.transform.localScale = Vector3.one * Random.Range(0.5f, 0.8f);
                }
                doneSpawning = true;
                break;

        }
    }

    public IEnumerator CheckFinished()
    {
        if (doneSpawning && counter >= virusNo)
        {
            PlayerPrefs.SetInt("Win", 1);
            PlayerPrefs.SetInt("Level", level);
            done = true; 
            inviroment.sprite = cleanInviroment;
            yield return new WaitForSeconds(0.5f);
            popUp.SetActive(true);
            popUp.GetComponent<SpriteRenderer>().sprite = winningPopUp; 
        }
    }

}
