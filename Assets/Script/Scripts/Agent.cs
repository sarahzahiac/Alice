using UnityEngine;

public class Agent : MonoBehaviour
{
    public Transform Target;
    public float speed = 3.5f; // vitesse personnalisée
 
    private UnityEngine.AI.NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed; // appliquer la vitesse
    }
    void Update()
    {
        agent.SetDestination(Target.position);
    }
}