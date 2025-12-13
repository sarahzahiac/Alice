using UnityEngine;

public class InteractionObstacle : MonoBehaviour
{
    public string requiredItem;
    public Material highlightMaterial;
    private Material originalMaterial;

    private InteractionInventory inventory;
    private Headbob headbob;
    private MeshRenderer mesh;

    void Start()
    {
        InputManager manager = FindObjectOfType<InputManager>();
        if (manager != null)
        {
            inventory = manager.interaction;
            headbob = manager.headbob;
        }

        mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
            originalMaterial = mesh.material;
    }

    public void SetHighlight(bool state)
    {
        if (mesh == null)
            return;

        if (highlightMaterial == null && state)
            return; 

        mesh.material = state ? highlightMaterial : originalMaterial;
    }

    public void InteractWithObstacle()
    {
        if (!inventory.HasItem(requiredItem))
        {
            headbob?.ShakeHead(0.2f, 0.05f, 0.5f);
            return;
        }

        Destroy(gameObject);
    }

}
