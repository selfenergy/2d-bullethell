using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [Tooltip("Initial health.")]
    public int health;
    private int currentHealth;
    [Tooltip("Optional healthBar object that will be horizontally scaled according to the remaining health / initial health ratio.")]
    public GameObject healthBar;
    [Tooltip("Collision layer that damages this entitz.")]
    public BulletTag damagedBy;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    public void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == damagedBy.ToString())
        {
            var bulletMover = other.gameObject.GetComponent<LinearMover>();
            if (bulletMover != null)
            {
                currentHealth -= bulletMover.damage;
                healthBar.transform.localScale = new Vector3(currentHealth / (float)health, 1, 1);
                if (currentHealth <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
