using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashVFX; //add Explosion VFX particle sysyem here
    void OnTriggerEnter(Collider other) //because onCollisionEnter worrks with objs with rigid body
    {
        Debug.Log($"{this.name} is **Triggered by** {other.gameObject.name}");
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false; //making the ship disappear
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<BoxCollider>().enabled = false; //to prevent colliding more than once
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

// add this script to player ship and add Rigid Body component to player ship to activate the physics system
// turn off use gravity

// no need OnCollisionEnter for player

// static collider - obj with collider but without rigid body
// turn on isTrigger and is kinematic in player ship

// When player crashes into something 
    // Disable player controls
    // Wait 1 second 
    // Reload the level
