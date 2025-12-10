using UnityEngine;
using System.Collections;

public class InteractionTriggerMur : MonoBehaviour
{
    public float descendAmount = 3f;
    public float speed = 0.8f;

    public AudioSource audioSrc;
    public AudioClip descendClip;

    Vector3 startPos;
    Vector3 endPos;
    bool lowered = false;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector3.down * descendAmount;

        if (audioSrc != null)
            audioSrc.playOnAwake = false;
    }

    public void DescendreMur()
    {
        StopAllCoroutines();
        StartCoroutine(MoveWall());
    }

    IEnumerator MoveWall()
    {
        Vector3 target = lowered ? startPos : endPos;
        lowered = !lowered;

        if (audioSrc && descendClip)
        {
            audioSrc.clip = descendClip;
            audioSrc.loop = true;
            audioSrc.Play();
        }

        while ((transform.position - target).sqrMagnitude > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                Time.deltaTime * speed
            );
            yield return null;
        }

        if (audioSrc)
        {
            audioSrc.loop = false;
            audioSrc.Stop();
        }
    }
}
