using UnityEngine;

public class TriggeredSpawner : MonoBehaviour
{
    [Tooltip("Actual bullet spawner that will be called upon player input.")]
    public BulletSpawner bulletSpawner;

    private IBulletTriggerActivated bulletTriggerActivated;
    // Update is called once per frame

    public void Start()
    {
        bulletTriggerActivated = GetComponent<IBulletTriggerActivated>();
    }

    public void Update()
    {
        if (bulletTriggerActivated.bulletTriggerIsActivated())
        {
            bulletSpawner.Update();
        }
    }
}

