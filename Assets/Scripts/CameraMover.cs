using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Tooltip("Object that the camera should follow.")]
    public GameObject player;
    private Vector3 offset;

    public void Start()
    {
        offset = transform.position - player.transform.position;
    }

    public void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
