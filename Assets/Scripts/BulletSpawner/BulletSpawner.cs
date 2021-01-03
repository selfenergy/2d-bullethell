using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour
{
    [Tooltip("Prototype of the bullets to spawn.")]
    public GameObject bullet;
    [Tooltip("Pause in milliseconds between bullet generation.")]
    public int shotRateInMilliseconds;
    [Tooltip("Collision layer tag that will be associated with the spawned bullets.")]
    public BulletTag bulletTag;
    protected float timeSinceLastBullet = 0;

    // Update is called once per frame
    public abstract void Update();
}
