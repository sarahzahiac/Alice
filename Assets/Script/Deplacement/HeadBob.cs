using UnityEngine;

public class Headbob : MonoBehaviour
{
    [Header("Normal headbob")]
    public Transform camHolder;
    public float amplitude = 0.1f;
    public float frequence = 10f;

    private Vector3 startPos;
    private Vector2 moveInput;

    [Header("Shake head reaction")]
    private bool isShaking = false;
    private float shakeDuration = 0f;
    private float shakeForce = 0f;
    private float shakeSpeed = 0f;
    private float shakeTimer = 0f;

    void Awake()
    {
        startPos = camHolder.localPosition;
    }

    public void ReceiveMovement(Vector2 input)
    {
        moveInput = input;
    }

    public void ShakeHead(float duration, float force, float speed)
    {
        isShaking = true;
        shakeDuration = duration;
        shakeForce = force;
        shakeSpeed = speed;
        shakeTimer = 0f;
    }

    void Update()
    {
        if (isShaking)
        {
            shakeTimer += Time.deltaTime * shakeSpeed;
            float t = shakeTimer / shakeDuration;

            if (t < 1f)
            {
                float x = Mathf.Sin(t * Mathf.PI * 2f) * shakeForce;
                camHolder.localPosition = startPos + new Vector3(x, 0f, 0f);
            }
            else
            {
                isShaking = false;
            }
            return;
        }

        bool moving = moveInput.sqrMagnitude > 0.01f;

        if (moving)
        {
            float y = Mathf.Sin(Time.time * frequence) * amplitude;
            camHolder.localPosition = startPos + new Vector3(0f, y, 0f);
        }
        else
        {
            camHolder.localPosition = Vector3.Lerp(camHolder.localPosition, startPos, Time.deltaTime * 10f);
        }
    }
}

// https://www.youtube.com/watch?v=5MbR2qJK8Tc
