using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Text currentScore;
    public Text bestScore;

    public Bean_Spawner spawner;

    public GameObject endPanel;

    public float moveSpeed = 600f;
    
    private float movement = 0f;
    private float start_X = 0;

    private bool isMove = false;

    private void Start()
    {
        Time.timeScale = 1;
        endPanel.SetActive(false);
    }

    void Update () {

        if (!isMove)
            movement = 0;

        if (Input.GetMouseButtonDown(0))
        {
            isMove = true;
            start_X = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            if (start_X > Input.mousePosition.x)
            {
                //좌로 이동 = -1
                movement = -1;
            }
            else if (Input.mousePosition.x > start_X)
            {
                //우로 이동 = 1
                movement = 1;
            }
            else
            {
                //정지 = 0
                movement = 0;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMove = false;
        }
	}

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spawner.score > PlayerPrefs.GetInt("Bean_BestRecord"))
            PlayerPrefs.SetInt("Bean_BestRecord", spawner.score);

        currentScore.text = spawner.score.ToString();
        bestScore.text = PlayerPrefs.GetInt("Bean_BestRecord").ToString();

        endPanel.SetActive(true);
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickToHome()
    {
        PlayerPrefs.SetString("NextScene", "Main");
        SceneManager.LoadScene("LoadingScene");
    }

    public void OnClickToRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
