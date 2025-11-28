using UnityEngine;

public class Headbob : MonoBehaviour
{
    public Transform cam;
    public float amplitude = 0.03f;
    public float frequency = 10f;

    private Vector3 startPos;
    private PlayerInput input;
    private PlayerInput.OnFootActions onFoot;

    void Awake()
    {
        input = new PlayerInput();
        onFoot = input.OnFoot;

        if (cam == null)
            cam = Camera.main.transform;

        startPos = cam.localPosition;
    }

    void OnEnable()
    {
        onFoot.Enable();
    }

    void OnDisable()
    {
        onFoot.Disable();
    }

    void Update()
    {
        Vector2 move = onFoot.Movement.ReadValue<Vector2>();
        bool isMoving = move.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            float bob = Mathf.Sin(Time.time * frequency) * amplitude;
            cam.localPosition = startPos + new Vector3(0f, bob, 0f);
        }
        else
        {
            cam.localPosition = Vector3.Lerp(cam.localPosition, startPos, Time.deltaTime * 10f);
        }
    }
}
