using UnityEngine;

public class planeTrigger : MonoBehaviour {

    GameObject Ground;

    // Use this for initialization
    void Start () {
        Ground = new GameObject();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //與pt物件綁定
    void OnTriggerEnter(Collider e)
    {
        //當人物碰到pt物件時，若此pt是GroundTwo的pt，代表人物已跑到GroundTwo，則GroundOne往前(Z軸)移動197.6f，
        //若此pt是GroundOne的pt，代表人物從GroundTwo又跑到GroundOne，則GroundTwo往前(Z軸)移動197.6f。
        //藉著不斷重複以上動作來達到無限跑道
        if (e.CompareTag("Player"))
        {
            if (gameObject.transform.parent.CompareTag("GroundTwo"))
            {
                Ground = GameObject.FindGameObjectWithTag("GroundOne");
                Ground.transform.position = new Vector3(44, 35.1f, Ground.transform.position.z + 197.6f);
            }
            else
            {
                Ground = GameObject.FindGameObjectWithTag("GroundTwo");
                Ground.transform.position = new Vector3(44, 35.1f, Ground.transform.position.z + 197.6f);
            }
            //只要人碰到pt就讓海(Wave)物件往前移動
            GameObject.FindGameObjectWithTag("Wave").transform.position += new Vector3(0, 0, 100);
        }
    }

}
