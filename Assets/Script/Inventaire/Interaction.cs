using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionInventaire : MonoBehaviour
{
    public Camera camera;
    public TMP_Text itemPickText;
    private List<string> inventory = new List<string>();


    public void InteractPressed()
    {
        RaycastHit hit;

        Vector3 pointVisee = camera.transform.position + camera.transform.forward * 0.5f;
        if (Physics.Raycast(pointVisee, camera.transform.forward, out hit, 1.8f))
        {
            string itemName = hit.collider.gameObject.name;
            if (itemName == "Key" || itemName == "Crowbar") 
            {
                AddToInventory(itemName);
                ShowItemPickedText(itemName);
                Debug.Log("Objet ramassé : " + itemName);
                Destroy(hit.collider.gameObject);
            }

        }

    }

    void AddToInventory(string itemName)
    {
        inventory.Add(itemName);

        Debug.Log("Inventaire actuel :");
        foreach (string item in inventory)
            Debug.Log(" - " + item);
    }

    void ShowItemPickedText(string itemName)
    {
        itemPickText.text = "Picked up " + itemName;
        StartCoroutine(FadeText(itemPickText));
    }

    IEnumerator FadeText(TMP_Text text)
    {
        text.gameObject.SetActive(true);
        text.canvasRenderer.SetAlpha(0f);

        text.CrossFadeAlpha(1f, 1f, false);
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(1f);

        text.CrossFadeAlpha(0f, 1f, false);
        yield return new WaitForSeconds(1f);

        text.gameObject.SetActive(false);
    }
}

// https://www.youtube.com/watch?v=iOdxMFt7RYQ&t=107s