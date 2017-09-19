using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//控制遊戲的流程進行
public class gameUI : MonoBehaviour {

    public Text pauseText, scoreText;
    //gameActiveState代表遊戲為開始(true)或暫停(false)
    public static bool gameActiveState = false;
    public GameObject StartButton, RestartButton, QuitButton, PauseButton;

    // Use this for initialization
    void Start () {
        //遊戲一開始時，使RestartButton、PauseButton生效
        RestartButton.SetActive(false);
        PauseButton.SetActive(false);
        //啟用多點觸控，這好像是不必要的，有空再研究
        Input.multiTouchEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //按ESC切換遊戲狀態
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameActiveStateSwitch();
        }
        //更新遊戲分數
        updateScore();
    }

    //切換遊戲狀態
    public void gameActiveStateSwitch()
    {
        //gameActiveState為true時，切換為false，pauseText設為Return，使RestartButton、QuitButton生效
        if(gameActiveState)
        {
            gameActiveState = false;
            pauseText.text = "Return";
            RestartButton.SetActive(true);
            QuitButton.SetActive(true);
        }
        //gameActiveState為false時，切換為true，pauseText設為Pause，使RestartButton、QuitButton失效
        else if (!gameActiveState)
        {
            gameActiveState = true;
            pauseText.text = "Pause";
            RestartButton.SetActive(false);
            QuitButton.SetActive(false);
        }
    }

    //與StartButton綁定
    public void gameStart()
    {
        //使StartButton、QuitButton失效，gameActiveState設為true，PauseButton生效
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        gameActiveState = true;
        PauseButton.SetActive(true);
    }

    //與RestartButton綁定
    public void gameRestart()
    {
        //重新載入此場景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //與QuitButton綁定
    public void gameQuit()
    {
        //結束程式
        Application.Quit();
    }

    //更新分數
    public void updateScore()
    {
        //分數計算方式：(人物目前所在位置Z軸-18)/10。人物一開始的Z軸為18
        scoreText.text = "Score:" + ((int)(GameObject.FindWithTag("Player").transform.position.z - 18) / 10);
    }
}
