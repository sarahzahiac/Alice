using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class InteractionInventory : MonoBehaviour
{
    public Camera cam;
    public TMP_Text pickUpText;
    public TMP_Text pickUpJournal;   


    private List<string> inventory = new List<string>();



    void Start()
    {
        if (pickUpJournal != null)
            pickUpJournal.gameObject.SetActive(false);
    }
    // Système pour interagir avec TOUT les objets

    public void Interact()
    {
        if (cam == null)
            cam = Camera.main; 
        

        RaycastHit hit;

        Vector3 viewStart = cam.transform.position + cam.transform.forward * 0.5f;

        if (Physics.Raycast(viewStart, cam.transform.forward, out hit, 5f))
        {
            string objectName = hit.collider.gameObject.name;

            // Ici on va vérifier si l'objet est une clé ou un pied de biche
            if (objectName.StartsWith("Key") || objectName.StartsWith("Crowbar"))
            {
                inventory.Add(objectName.StartsWith("Key") ? "Key" : "Crowbar");
                ShowPickup(objectName);
                Destroy(hit.collider.gameObject);
                return;
            }

            InteractionDoor door = hit.collider.GetComponent<InteractionDoor>();
            if (door != null)
            {
                door.InteractDoor();
                return;
            }

            InteractionDoorCadena lockedDoor = hit.collider.GetComponent<InteractionDoorCadena>();
            if (lockedDoor != null)
            {
                lockedDoor.InteractDoor();
                return;
            }

            InteractionDoorBarricaded barricadedDoor = hit.collider.GetComponent<InteractionDoorBarricaded>();
            if (barricadedDoor != null)
            {
                barricadedDoor.InteractDoor();
                return;
            }

            journalRecuperation page = hit.collider.GetComponent<journalRecuperation>();
            if (page != null)
            {
                page.InteractPage();

                if (pickUpJournal != null)
                {
                    pickUpJournal.gameObject.SetActive(true);
                    pickUpJournal.text = "Journal Pages: " + journalRecuperation.pagesCollected + "/" + journalRecuperation.totalPages;
                    if (journalRecuperation.pagesCollected >= journalRecuperation.totalPages)
                    {
                        pickUpJournal.gameObject.SetActive(false);
                    }
                }

                return;
            }


            // Ici on va vérifier si le l'objet a le script InteractionObstacle, si oui on lance le script de interactWithObstacle
            InteractionObstacle obstacle = hit.collider.GetComponent<InteractionObstacle>();
            if (obstacle != null)
                obstacle.InteractWithObstacle();
        }
    }


    // Ca va etre utile pour interactionObstacle
    public bool HasItem(string item)
    {
        return inventory.Contains(item);
    }

    // Afficher le texte de ramassage
    private void ShowPickup(string name)
    {
        pickUpText.text = "Picked up " + name;
        StartCoroutine(FadeText(pickUpText));
    }

    public IEnumerator FadeText(TMP_Text txt)
    {
        txt.gameObject.SetActive(true);
        txt.canvasRenderer.SetAlpha(0f);

        txt.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1f);

        txt.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);

        txt.gameObject.SetActive(false);
    }
}

// https://www.youtube.com/watch?v=iOdxMFt7RYQ
