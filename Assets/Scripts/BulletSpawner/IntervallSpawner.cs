using UnityEngine;

public class IntervallSpawner : BulletSpawner
{
    // Update is called once per frame
    public override void Update()
    {
        timeSinceLastBullet += Time.deltaTime;
        if (timeSinceLastBullet * 1000 > shotRateInMilliseconds)
        {
            timeSinceLastBullet = 0;
            var newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.tag = bulletTag.ToString();
        }
    }
}
