using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 4f;
    public float jumpHeight = 1.2f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("End Point")]
    public Transform endPoint;
    public float reachDistance = 2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < -2f)
            velocity.y = -2f;

        CheckEndPoint();
    }

    public void ProcessMove(Vector2 input)
    {
        // On gère le déplacement ici
        Vector3 move = (Camera.main.transform.forward * input.y) + (Camera.main.transform.right * input.x);
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Le joueur a été touché par l'ennemi
            FindObjectOfType<PlayerLook>().SetCursorState(true);  // Déverrouille le curseur avant de charger la scène
            LoadGameOverScene();
        }
    }

    void CheckEndPoint()
    {
        float distance = Vector3.Distance(transform.position, endPoint.position);

        if (distance <= reachDistance)
        {
            Debug.Log("Fin atteinte");
            LoadEndScene();
        }
    }

    // Changement de scène
    void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
