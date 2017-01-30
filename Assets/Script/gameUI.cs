using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour {

    public Text pauseText, scoreText;
    public static bool gameActiveState = false;
    public GameObject StartButton, RestartButton, QuitButton, PauseButton, playerGB;

    // Use this for initialization
    void Start () {
        RestartButton.SetActive(false);
        PauseButton.SetActive(false);
        Input.multiTouchEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {

	    if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStart();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameActiveStateSwitch();
        }

        updateScore();
    }

    public void gameActiveStateSwitch()
    {
        if(gameActiveState)
        {
            gameActiveState = false;
            pauseText.text = "Return";
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);
            Time.timeScale = 0;
        }
        else if(!gameActiveState)
        {
            gameActiveState = true;
            pauseText.text = "Pause";
            RestartButton.SetActive(false);
            QuitButton.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void gameStart()
    {
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        gameActiveState = true;
        PauseButton.SetActive(true);
    }

    public void gameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void gameQuit()
    {
        Application.Quit();
    }

    public void updateScore()
    {

        scoreText.text = "Score:" + (int.Parse(playerGB.transform.position.z.ToString()) - 18);
    }
}
