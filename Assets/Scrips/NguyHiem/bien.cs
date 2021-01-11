using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bien : MonoBehaviour
{
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(5);
        }
    }
}
