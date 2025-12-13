using UnityEngine;
using System.Collections;

public class InteractionDoorCadena : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;

    public GameObject lockObject;  

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private Coroutine currentCoroutine;

    private Headbob headbob;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, openAngle, 0f));

        headbob = FindObjectOfType<Headbob>();
    }

    public void InteractDoor()
    {
        if (lockObject != null)
        {
            headbob?.ShakeHead(0.2f, 0.05f, 0.5f);
            return;
        }
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(ToggleDoor());
    }

    private IEnumerator ToggleDoor()
    {
        Quaternion target = isOpen ? closedRotation : openRotation;
        isOpen = !isOpen;

        while (Quaternion.Angle(transform.rotation, target) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                target,
                Time.deltaTime * openSpeed
            );
            yield return null;
        }
    }
}

// https://www.youtube.com/watch?v=smlgtS07jaQ