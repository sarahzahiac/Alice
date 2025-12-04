using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
private PlayerInput playerinput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    public InteractionInventaire interaction; 
    public Headbob headbob; 

    void Awake()
    {
        playerinput = new PlayerInput();
        onFoot = playerinput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        headbob = GetComponent<Headbob>(); 

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Interact.performed += ctx => interaction.InteractPressed();
    }

    void Update() 
    {
        Vector2 lookInput = onFoot.Look.ReadValue<Vector2>();
        look.ProcessLook(lookInput);
    }

    void FixedUpdate()
    {
        Vector2 moveInput = onFoot.Movement.ReadValue<Vector2>(); 
        
        motor.ProcessMove(moveInput); 
        
        if (headbob != null)
        {
            headbob.ReceiveMovementInput(moveInput); 
        }
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}


// https://www.youtube.com/watch?v=rJqP5EesxLk&t=465s