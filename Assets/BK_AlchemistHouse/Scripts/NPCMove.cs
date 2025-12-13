using UnityEngine;

public class NPCMoveOnProximity : MonoBehaviour
{
    [Header("Player Detection")]
    public Transform player;
    public float triggerDistance = 5f;

    [Header("Movement")]
    public Transform targetPoint; 
    public float moveSpeed = 2f;

    [Header("Animation")]
    public Animator animator; // must have "Walk" parameter

    private bool isTriggered = false;

    void Update()
    {
        // Calculate distance between player and NPC
        float distance = Vector3.Distance(player.position, transform.position);

        // If the player is close & not already triggered
        if (!isTriggered && distance <= triggerDistance)
        {
            isTriggered = true;
            animator.SetBool("Walk", true); // play walk animation
        }

        // Move NPC if triggered
        if (isTriggered)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Move NPC toward the target position
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            moveSpeed * Time.deltaTime
        );

        // When NPC reaches the point → stop and disappear
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            animator.SetBool("Walk", false); // stop walking
            Destroy(gameObject, 0.5f); // disappear after 0.5 seconds
        }
    }
}
