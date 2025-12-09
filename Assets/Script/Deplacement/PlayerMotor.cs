using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 4f;
    public float jumpHeight = 1.2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < -2f)
            velocity.y = -2f;
    }

    public void ProcessMove(Vector2 input)
    {
        // On gère le tdéplacement ici
        Vector3 move =
            (Camera.main.transform.forward * input.y) +
            (Camera.main.transform.right * input.x);

        move.y = 0f;

        move = Vector3.ClampMagnitude(move, 1f);

        controller.Move(move * speed * Time.deltaTime);

        // On va appliquer la gravité ici 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
// https://www.youtube.com/watch?v=rJqP5EesxLk&t=465s 
//  https://docs.unity3d.com/ScriptReference/CharacterController.Move.html