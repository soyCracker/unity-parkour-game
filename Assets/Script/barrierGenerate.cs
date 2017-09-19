using UnityEngine;

public class barrierGenerate : MonoBehaviour {

    public GameObject barrier;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //與bg物件綁定
    void OnTriggerEnter(Collider e)
    {
        //當人碰到bg物件就觸發障礙物產生
        if (e.CompareTag("Player"))
        {
            //取得bg物件的父母，GroundOne或GroundTwo的位置
            Vector3 planePos = gameObject.transform.parent.position;           
            //i=3、0、-3，X軸，3個跑道
            for(int i=-3;i<4;i+=3)
            {
                //每個跑道各產生2個障礙物
                for(int j=0;j<2;j++)
                {
                    //亂數種子，產生亂數的方法
                    int seed = System.Guid.NewGuid().GetHashCode();
                    Random.InitState(seed);
                    //障礙物Z軸=GroundOne或GroundTwo的Z軸+50+(j*50) ~ GroundOne或GroundTwo的Z軸+100+(j*50) 之間
                    Vector3 barrierPos = new Vector3(i, 2.5f, Random.Range(planePos.z + 50 + (j * 50), planePos.z + 100 + (j * 50)));
                    //產生障礙物
                    Instantiate(barrier, barrierPos, transform.rotation);
                }
            }
        }
    }
}
