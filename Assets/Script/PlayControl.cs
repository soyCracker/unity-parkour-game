using UnityEngine;
using System.Collections.Generic;

public class PlayControl : MonoBehaviour {

    [SerializeField] private float m_moveSpeed = 7f;
    [SerializeField] private float m_jumpForce = 6f;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;

    private float m_currentV = 0;
    private readonly float m_interpolation = 10;
    private bool m_wasGrounded;
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_isGrounded;
    private bool touchUp = false;
    private Vector2 touchPos = new Vector2();
    private List<Collider> m_collisions = new List<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for(int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider)) {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if(validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        } else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

	void Update () {
        m_animator.SetBool("Grounded", m_isGrounded);

        if(gameUI.gameActiveState)
        {
            runUpdate();
        }

        //runUpdate();

        m_wasGrounded = m_isGrounded;
    }

    //設定人物的跳躍，必須判定人物落地了沒
    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.Space)||touchUp))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            touchUp = false;
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    private void runUpdate()
    {
        float v = 5;

        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        transform.position += transform.forward * m_currentV * m_moveSpeed * Time.deltaTime;     
        m_animator.SetFloat("MoveSpeed", m_currentV);

        //按右方鍵，且人物X軸不為3時，向右移動
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3)
        {
            transform.position += Vector3.right * 3;
        }
        //按左方鍵，且人物X軸不為-3時，向左移動
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3)
        {
            transform.position += Vector3.left * 3;
        }

        //觸控操作
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                touchPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                Vector2 touchEndPos = Input.touches[0].position;
                if (Mathf.Abs(touchEndPos.x - touchPos.x) > Mathf.Abs(touchEndPos.y - touchPos.y))
                {
                    if (touchEndPos.x > touchPos.x && transform.position.x < 3)
                    {
                        transform.position += Vector3.right * 3;
                    }
                    else if (touchEndPos.x < touchPos.x && transform.position.x > -3)
                    {
                        transform.position += Vector3.left * 3;
                    }
                }
                else if(touchEndPos.y > touchPos.y)
                {
                    touchUp = true;
                }
            }
        }

        JumpingAndLanding();
    }
}
