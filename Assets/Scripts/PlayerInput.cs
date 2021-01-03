using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IBulletTriggerActivated
{
    [Tooltip("The speed of the player.")]
    public float speed;
    [Tooltip("InputAction object that contains the player inputs.")]
    public InputAction inputAction;
    [Tooltip("Prototype of bullets to spawn when shooting.")]
    public GameObject bullet;
    public int shotRateInMilliseconds;
    private new Rigidbody2D rigidbody;
    private Vector2 moveDirection;
    private bool shooting = false;
    private bool slow = false;
    private float timeSinceLastBullet = 0;
    private bool bulletTriggerActivated = false;

    public bool bulletTriggerIsActivated()
    {
        return bulletTriggerActivated;
    }

    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        shooting = value.Get<float>() > 0;
    }
    public void OnSlow(InputValue value)
    {
        slow = value.Get<float>() > 0;
    }

    public void Update()
    {
        rigidbody.velocity = slow ? moveDirection * speed / (float)2 : moveDirection * speed;
        timeSinceLastBullet += Time.deltaTime;
        if (shooting && timeSinceLastBullet * 1000 > shotRateInMilliseconds)
        {
            timeSinceLastBullet = 0;
            var newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.tag = "Player";
        }
    }
}
