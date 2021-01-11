using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject died, addhp;
    public int Health = 100;

 
    // Update is called once per frame
    void Update()
    {
        if (Health <=0)
        {
            Destroy(gameObject);
        }
    }
    void Damage(int damage)
    {
        Health -= damage;
    }
}
