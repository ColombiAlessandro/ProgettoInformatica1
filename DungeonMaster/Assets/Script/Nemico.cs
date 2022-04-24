using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Nemico : MonoBehaviour
{
    [SerializeField] float velocitÓN;
    [SerializeField] GameObject giocatore;
    [SerializeField] public int vite;
    [SerializeField] GameObject pozione;
    public Player player;
    private int rilascioPozione;
    private void Start()
    {
        player = giocatore.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        inseguimento();
        if (player.velocita == 0 && player.vite != 0)
            velocitÓN = 0;
        else if(player.velocita!=0)
            velocitÓN = 0.2f;
    }
    public void inseguimento()
    {
        if (giocatore != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, giocatore.transform.position, velocitÓN * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.attacco == true)
            {
                PerditaVite();
            }
        }
    }
    public void PerditaVite()
    {
        vite--;
        if (vite == 0)
        {
            rilascioPozione = UnityEngine.Random.Range(0, 6);
            if (rilascioPozione == 1)
            {
                Instantiate(pozione, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    

}
