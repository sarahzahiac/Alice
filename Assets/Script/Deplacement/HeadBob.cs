using UnityEngine;

public class Headbob : MonoBehaviour
{
    public Transform camHolder; 
    public float amplitude = 0.1f;
    public float frequency = 10f;

    private Vector3 startPos;
    private Vector2 currentMoveInput;

    void Awake()
    {
        startPos = camHolder.localPosition;
    }

    public void ReceiveMovementInput(Vector2 input)
    {
        currentMoveInput = input;
    }

    void Update()
    {
        bool isMoving = currentMoveInput.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            float bob = Mathf.Sin(Time.time * frequency) * amplitude;
            camHolder.localPosition = startPos + new Vector3(0f, bob, 0f);
        }
        else
        {
            camHolder.localPosition = Vector3.Lerp(camHolder.localPosition, startPos, Time.deltaTime * 10f);
        }
    }
}

// Inspiration  https://www.youtube.com/watch?v=5MbR2qJK8Tc et https://www.youtube.com/watch?v=5MbR2qJK8Tc