using UnityEngine;

public class Gui : MonoBehaviour
{
    public Texture2D mainTexture;
    public Texture2D cercleTexture;
    public float tailleMain = 0.2f;
    public float tailleCercle = 0.1f;

    private InteractionObstacle obstacleActuel = null;


    // Ici ca sera l'affichage avec la main etc. Ca vient principalement de la vidéo de Creak Games sur l'inventaire
    void OnGUI()
    {
        if (obstacleActuel != null)
        {
            obstacleActuel.SetHighlight(false);  
            obstacleActuel = null;
        }

        if (Camera.main == null)
        return;

        // Check if we are currently pointing at an object
        RaycastHit hit;
        Vector3 departVisuel = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;

        bool isHandImageActive  = false;

        if (Physics.Raycast(departVisuel, Camera.main.transform.forward, out hit, 5f))
        {
            // Calculate the screen position of the hit point
            Vector3 posEcran = Camera.main.WorldToScreenPoint(hit.point);

            if (hit.collider.name.StartsWith("Key") || hit.collider.name.StartsWith("Crowbar")|| hit.collider.name.StartsWith("Door") || hit.collider.name.StartsWith("DoorLock") || hit.collider.name.StartsWith("DoorBarricaded") || hit.collider.name.StartsWith("journal"))
            {
                isHandImageActive  = true;

                GUI.DrawTexture(new Rect(
                    posEcran.x - (mainTexture.width * tailleMain / 2),
                    Screen.height - posEcran.y - (mainTexture.height * tailleMain / 2),
                    mainTexture.width * tailleMain,
                    mainTexture.height * tailleMain),
                    mainTexture);
            }



            InteractionObstacle obstacle = hit.collider.GetComponent<InteractionObstacle>();
            if (obstacle != null)
            {
                obstacle.SetHighlight(true);  
                obstacleActuel = obstacle;
            }
        }

        if (!isHandImageActive )
        {
            // Calculate the screen position of the forward point
            Vector3 pos = Camera.main.WorldToScreenPoint(Camera.main.transform.position + Camera.main.transform.forward * 2f);

            GUI.DrawTexture(new Rect(
                pos.x - (cercleTexture.width * tailleCercle / 2),
                Screen.height - pos.y - (cercleTexture.height * tailleCercle / 2),
                cercleTexture.width * tailleCercle,
                cercleTexture.height * tailleCercle),
                cercleTexture);
        }
    }
}

// https://www.youtube.com/watch?v=iOdxMFt7RYQ
