using UnityEngine;

public class LinearMover : MonoBehaviour
{
    public float speed;
    public int damage;
    private new Rigidbody2D rigidbody;
    public void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rigidbody.velocity = transform.up * speed;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
