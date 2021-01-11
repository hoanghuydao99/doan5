using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoang : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moviRight = true;
    public Transform groundDetection;
    public player p;
    public GameObject plr;
    private bool move = true;
    private bool isDMG = false;

    //public GameObject deathEffect;
    private void Update()
    {
        
        if (move) transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false)
        {

            if (moviRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moviRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moviRight = true;
            }
        }
        if (Vector3.Distance(this.transform.position, plr.transform.position) < 1.1f)
        {
            

            move = false;

            if (!isDMG)
            {
                StartCoroutine(damage());
                isDMG = true;
                
            }

            this.GetComponent<Animator>().SetTrigger("Atk");
            if (moviRight && plr.transform.position.x < this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moviRight = false;

            }
            if (!moviRight && plr.transform.position.x > this.transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moviRight = true;

            }
        }
        else
        {
            move = true;
            this.GetComponent<Animator>().SetTrigger("Move");
        }

    }

    public IEnumerator damage()
    {
        yield return new WaitForSeconds(1);
        //p.ourHealth -= 1;
        p.maxHealth -= 1;
        isDMG = false;
    }
    //private void Die()
    //{
    //    Instantiate(deathEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}

}
