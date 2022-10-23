using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] GameObject deathVFX;//not ParticleSystem because this is directly dropped into the world
    [SerializeField] GameObject hitVFX;
    // [SerializeField] Transform parent; //Transform - becaus ethe empty gameObj has only Transform in it
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreBoard; //instead of adding this script to every enemy
    GameObject parentGameObject; //alternate method - now referencing the whole obj

    void Start()
    {
        // there are many ways to refer to an obj, this is one such way
        // FindObjectOfType finds the first instance of the obj - don't use this method in update
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();

    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>(); //to identify the colliders in various levels
        rb.useGravity = false;
    }

  void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
        
    }

    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform; //using .transform as the type is gameObj
        
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform; 
        Destroy(gameObject);
    }

}

// to set deathVFX to all enemy, select them all and drag drop the Enemy Explosion VFX into the Serialized field

// Instantiate(what is the obj to be instantiated, where it should instantiate, Quaternion rotation)
// Quaternion.identity - no rotation needed here

// Turn on Play on Awake in Enemy Explosion VFX

// The Enemy explosion alters the name of the enemy while the game is on to rectify this create an empty game object "Spawn At Runtime" reposition to 0,0,0

// select all enemies and set the parent to "Spawn At Runtime"
// now the particle effects sit inside the parent when game is on

// Add Spawn At Runtime to Prefabs

// Add Self Destruct script to hitVFX prefab

