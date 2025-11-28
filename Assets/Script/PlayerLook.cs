using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera playerCamera;
    public float xSensitivity = 20f;
    public float ySensitivity = 20f;
    private float xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x; 
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);


    }

}
