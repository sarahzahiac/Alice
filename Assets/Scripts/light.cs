using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light lightToFlicker;    // La lumière qui clignote
    public float minIntensity = 0.5f; 
    public float maxIntensity = 2f;   
    public float flickerSpeed = 0.1f; 

    void Start()
    {
        if (lightToFlicker == null)
            lightToFlicker = GetComponent<Light>();
    }

    void Update()
    {
        // Changer l'intensité de façon random 
        lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity);
    }
}
