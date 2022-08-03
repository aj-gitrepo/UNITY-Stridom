using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;//not ParticleSystem because this is directly dropped into the world
    [SerializeField] Transform parent; //Transform - becaus ethe empty gameObj has only Transform in it
    void OnParticleCollision(GameObject other) 
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
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

