using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 3f;
    // To destroy the enemy particle effect stored in parent in game mode
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}

// add this to "Enemy Explosion VFX" prefab
