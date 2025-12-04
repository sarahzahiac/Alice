using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerinput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    public InteractionInventory interaction;
    public Headbob headbob;

    void Awake()
    {
        playerinput = new PlayerInput();
        onFoot = playerinput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        headbob = GetComponent<Headbob>();

        if (headbob == null)
            headbob = FindObjectOfType<Headbob>();

        onFoot.Jump.performed += ctx => motor?.Jump();

        onFoot.Interact.performed += ctx =>
        {
            if (interaction != null)
                interaction.Interact();
        };
    }

    void Update()
    {
        if (look != null)
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        Vector2 move = onFoot.Movement.ReadValue<Vector2>();
        motor?.ProcessMove(move);
        headbob?.ReceiveMovement(move);
    }

    private void OnEnable(){
        onFoot.Enable();
    }

    private void OnDisable(){
        onFoot.Disable();
    }

}

// https://www.youtube.com/watch?v=rJqP5EesxLk&t=355s
