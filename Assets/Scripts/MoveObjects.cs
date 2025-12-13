using UnityEngine;

public class SlightMovement : MonoBehaviour
{
    public float speed = 1f;
    public float max = 0.1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * max;
        transform.position = startPosition + new Vector3(offset, 0, 0); 
    }
}
