using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //與障礙物物件綁定，當角色撞到障礙物時，遊戲結束
    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
            //重新載入場景
            SceneManager.LoadScene(0);
            gameUI.gameActiveState = false;
        }
    }
}
