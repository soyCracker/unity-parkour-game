using UnityEngine;
using System.Collections;

public class playControl : MonoBehaviour {

    public float movespeed = 1f, jumpspeed = 700f;
    private bool isGround = true;
    private Vector2 touchPos = new Vector2();

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, -15.0f, 0);
        Input.multiTouchEnabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(gameUI.gameActiveState)
        {
            gameControl();
            touchControl();
        }       
    }

    void OnTriggerEnter(Collider e)
    {
        if (!isGround && (e.CompareTag("Plane1") || e.CompareTag("Plane2")))
        {
            isGround = true;
            Physics.gravity = new Vector3(0, -15.0f, 0);
        }
    }

    public void gameControl()
    {
        transform.Translate(Vector3.forward * movespeed);

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3)
        {
            transform.position += new Vector3(3, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3)
        {
            transform.position += new Vector3(-3, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpspeed);
            isGround = false;
        }

        if(!isGround && transform.position.y >= 3)
        {
            Physics.gravity = new Vector3(0, -40.0f, 0);
        }
    }

    public void touchControl()
    {
        if(Input.touchCount==1)
        {
            if(Input.touches[0].phase==TouchPhase.Began)
            {
                touchPos = Input.touches[0].position;
            }

            if(Input.touches[0].phase==TouchPhase.Ended)
            {
                Vector2 touchEndPos = Input.touches[0].position;
                if(Mathf.Abs(touchEndPos.x-touchPos.x)>Mathf.Abs(touchEndPos.y-touchPos.y))
                {
                    if(touchEndPos.x > touchPos.x && transform.position.x < 3)
                    {
                        transform.position += new Vector3(3, 0, 0);
                    }
                    else if(touchEndPos.x < touchPos.x && transform.position.x > -3)
                    {
                        transform.position += new Vector3(-3, 0, 0);
                    }
                }
                else
                {
                    if (touchEndPos.y > touchPos.y && isGround)
                    {
                        GetComponent<Rigidbody>().AddForce(transform.up * jumpspeed);
                        isGround = false;
                    }
                }
            }
        }
    }
}
