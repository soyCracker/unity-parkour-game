using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOverTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider e)
    {
        if (e.CompareTag("Player"))
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(0);
            gameUI.gameActiveState = false;
        }
    }
}
