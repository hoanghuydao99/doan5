using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trumboss : MonoBehaviour
{
    public int Health = 100;
    public GameObject win;


    void Awake()
    {
        win.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            win.SetActive(true);
        }
    }
    void Damage(int damage)
    {
        Health -= damage;
    }
}
