using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{

    public float speed = 50f, maxspeed = 3, maxjup = 4, jumpPow = 400f;
    public Rigidbody2D r2;
    public Animator anim;
    public bool grounded = true, faceright = true, doupbleJump = false;
    public int ourHealth;
    public int maxHealth = 10;
    //public Sounds sounds;
    public float kill2Delay = 0.3f;
    public bool kill2 = false;


    [SerializeField]
    private GameObject frieBallPrefab;

    public SoundManager sound;

    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        sound = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();

        //ourHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound.Playsound("4");
            if (grounded)
            {
                grounded = false;
                doupbleJump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            //nhay 2 lan
            else
            {
                if (doupbleJump)
                {
                    doupbleJump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.7f);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && !kill2)
        {
            sound.Playsound("3");
            kill2 = true;
            // trigger.enabled = true;
            anim.SetTrigger("Kill2");
            kill2Delay = 0.3f;
            _Kill2FrieBall(0);
        }

        if (kill2)
        {
            if (kill2Delay > 0)
            {
                kill2Delay -= Time.deltaTime;

            }
            else
            {
                kill2 = false;
                // trigger.enabled = false;

            }
        }
        anim.SetBool("Kill2", kill2);
    
}
    void FixedUpdate()
    {
        HealthBarScript.instance.Mau(maxHealth);
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);//2 cau lệnh để di chuyển
        //di chuyen sang phai
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        //di chuyen sang trai
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (r2.velocity.y > maxjup)
            r2.velocity = new Vector2(r2.velocity.x, maxjup);
        if (r2.velocity.y < -maxjup)
            r2.velocity = new Vector2(r2.velocity.x, -maxjup);

        if (h > 0 && !faceright)
        {
            Flip();
        }
        if (h < 0 && faceright)
        {
            Flip();
        }

        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        }
        if(maxHealth <= 0)
        {
            Death();
        }


 

    }

    public void Flip()
    {
        faceright = !faceright;
        //Vector3 Scale;
        //  Scale = transform.localScale;
        //  Scale.x *= -1;
        //  transform.localScale = Scale;
        transform.Rotate(0f, 180f, 0f);

    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Damage(int damage)
    {
        //ourHealth -= damage;
        maxHealth -= damage;
    
    }
    public void ItemHP(int hp)
    {
        sound.Playsound("1");
        if (maxHealth >= 10)
        {
            maxHealth += 0;
        }
        else
        {
            maxHealth += hp;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("cuchai")) {
            this.transform.parent = collision.transform;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (this.gameObject.activeSelf == true) this.transform.parent = null;
    }
    public void _Kill2FrieBall(int value)
    {


        if (faceright)
        {
            GameObject tmp = (GameObject)
            Instantiate(frieBallPrefab, new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z), Quaternion.Euler(new Vector3(0, -10, 0)));
            tmp.GetComponent<Kill2_FrieBall>().Initialize(Vector2.right);
        }
        else
        {

            GameObject tmp = (GameObject)
        Instantiate(frieBallPrefab, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(new Vector3(0, -10, -180)));
            tmp.GetComponent<Kill2_FrieBall>().Initialize(Vector2.left); ;

        }


    }
}