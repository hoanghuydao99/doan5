using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossaddhp : MonoBehaviour
{
    public GameObject died, addhp;
    public int Health = 100;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }
    void Damage(int damage)
    {
        Health -= damage;
    }
    void Die()
    {
        GameObject hp = Instantiate(addhp, transform.position, Quaternion.identity);
        Destroy(hp, 5f);

        GameObject ef = Instantiate(addhp, transform.position, Quaternion.identity);
        Destroy(ef, 0.5f);

        Destroy(gameObject);
    }
}
