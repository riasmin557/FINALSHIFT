using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private Animator anim;

    public float distanciaAtaque = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distacia=
            Vector3.Distance(transform.position, player.position);

        if (distacia > distanciaAtaque)
        {
            agent.SetDestination(player.position);
            anim.SetBool("Andar",true);
        }
        else
        {
            agent.SetDestination(transform.position);
            anim.SetBool("Andar", false);
            anim.SetTrigger("Attack");
        }

       
    }
}
