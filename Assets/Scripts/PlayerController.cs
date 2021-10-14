using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public Vector3 SpawnPoint;
    public Transform CheckPoint;
    public LayerMask RayLayer;
    public AudioSource JumpAudio;
    public HearthUI HearthUI;
    Rigidbody2D rb;
    Animator am;
    Text txt;

 
    private float RaycastLimit = 0.1f;
    [SerializeField]
    private float speed=4f;
    [SerializeField]
    private float JumpSpeed=10f;
    private float _Move, ScaleX;
  
    private bool grounded = true;
    private bool jump;
    private bool CanMove;

    public GameObject GroundObject;
    private BoxCollider2D BoxCollider2d;

    void Start()
    {
        Setting();
    }

    private void Setting()
    {
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ScaleX = transform.localScale.x;

        am.transform.position = SpawnPoint;
        CanMove = true;

        txt = GameObject.FindGameObjectWithTag("Coins").GetComponent<Text>();
        txt.text = "Coin : " + CoinsManager.Coins;

        GameManager.hearth = GameManager.hearthOrigin;
        GameManager.TxtCount = 1;

        HearthUI.createHeart();

        BoxCollider2d = GroundObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        Movement();
        GroundCheck();

        if (am.transform.position.y <= -10f) //load over
        {
            Dead();
        }

    }

    private void Movement()
    {
        if (CanMove)
        {
            _Move = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(_Move * speed, rb.velocity.y); //move
            am.SetFloat("speed", Abs(_Move));

            if (Input.GetButtonDown("Jump") && grounded && CanMove) //jump
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
                am.SetBool("jump", true);
                JumpAudio.Play();
            }

            if (jump && grounded && CanMove) //jump
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
                am.SetBool("jump", true);
                jump = false;
                JumpAudio.Play();
            }

            if (_Move > 0)  //scale
            {
                transform.localScale = new Vector3(ScaleX, transform.localScale.y, transform.localScale.z);
            }
            if (_Move < 0)
            {
                transform.localScale = new Vector3(-ScaleX, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            rb.velocity = new Vector2(0,0); 
            am.SetFloat("speed",0);
        }
    }
    private void GroundCheck()
    {
        RaycastHit2D BoxCenter = Physics2D.BoxCast(BoxCollider2d.bounds.center, BoxCollider2d.bounds.size, 0f, Vector2.down, RaycastLimit, RayLayer);
        if (BoxCenter.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }
   
    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.collider.gameObject.tag == "Enemy")
        {
            Dead();
        }
        if (Other.collider.gameObject.tag == "Ground")
        {
            am.SetBool("jump", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnPoint")
        {
            SpawnPoint = CheckPoint.transform.position;
        }
        if (collision.gameObject.tag == "Win")
        {
            GameManager.win = true;
            CanMove = false;
            Invoke("loadScene", 0.5f);
        }
    
    }

    float Abs(float x) //speed calculate
    {  
        return x >= 0f ? x : -x;
    }
    public void Dead()
    {
        GameManager.hearth -= 1;
        if (GameManager.hearth > 0)
        {

            am.transform.position = SpawnPoint;
            CanMove = false;
            Invoke("WalkOn", 0.5f);
        }
        else
        {
            loadScene();
        }
    }
    public void loadScene()  //load end scene
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    
  
    public void Jump(bool j)
    {
        jump = j;
    }
    public void Move(int a)
    {
        _Move = a;
    }
    public void Move2(int a)
    {
        _Move = a;
    }
    void WalkOn()
    {
        CanMove = true;
    }


}
