using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    public float xSensitivity = 100f;
    public float ySensitivity = 100f;

    private float xRotation = 0f;

    public void SetCursorState(bool isMenu)
    {
        if (isMenu)
        {
            Cursor.lockState = CursorLockMode.None;  // Déverrouille le curseur
            Cursor.visible = true;  // Affiche le curseur
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;  // Verrouille le curseur
            Cursor.visible = false;  // Cache le curseur
        }
    }

    public void ProcessLook(Vector2 input) 
    {
        float mouseX = input.x * Time.deltaTime * xSensitivity;
        float mouseY = input.y * Time.deltaTime * ySensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Start()
    {
        SetCursorState(false);  // Par défaut, verrouille et cache le curseur pour le gameplay
    }
}


//https://www.youtube.com/watch?v=rJqP5EesxLk&t=465s