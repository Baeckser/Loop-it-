﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemy_Gun;

    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    
    public float timeBetweenBullets = 1f;
    public float timeTilNextShot;
    public float startDelay = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        timeTilNextShot = Time.realtimeSinceStartup + startDelay;
    }

    // Update is called once per frame
    //Enemy firing projectile
    private void Update()
    {
            if (Time.realtimeSinceStartup > timeTilNextShot)
                fireEnemyProjectile();
    }
    void fireEnemyProjectile()
    {
        Instantiate(enemyProjectile, enemy_Gun.position, transform.rotation);
        timeTilNextShot = Time.realtimeSinceStartup + timeBetweenBullets;
    }

    //Despawning out of range enemies and collision with the Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Despawn")
        {
            Destroy(enemy);
        }
        
        if (collision.gameObject.tag == "Player")
        {
            Destroy(enemy);

            Player_2 temp = collision.gameObject.GetComponent<Player_2>();
            if (temp != null)
            {
                temp.Respawn();
            }

            GameManager.playGame = false;
        }
    }
}
