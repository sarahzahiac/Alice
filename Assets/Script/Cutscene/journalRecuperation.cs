using UnityEngine;

public class journalRecuperation : MonoBehaviour
{
    public InteractionTriggerMur mur;   

    public static int pagesCollected = 0;
    public static int totalPages = 10;

    private bool collected = false;

    public void InteractPage()
    {
        if (collected) return;

        collected = true;
        pagesCollected++;

        Destroy(gameObject);

        if (pagesCollected >= totalPages && mur != null)
        {
            Debug.Log("Toutes les pages récupérées !");
            mur.DescendreMur();
        }
    }
}
