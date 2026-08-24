using UnityEngine;
using UnityEngine.AI;

public class ZumbiSeguir : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private Animator anim;

    public float distanciaAtaque = 2f;

    public VidaPlayer jogador;
   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

       

    }

    // Update is called once per frame
    void Update()
    {
        if (agent == null || !agent.enabled || !agent.isOnNavMesh)
        {
            return;
        }

        float distacia =
            Vector3.Distance(transform.position, player.position);

        if (distacia > distanciaAtaque)
        {
            if (distacia < 10f)
            {
                agent.SetDestination(player.position);
                anim.SetBool("Andar", true);
            }
        }
        else
        {
            agent.SetDestination(transform.position);
            anim.SetBool("Andar", false);
            anim.SetTrigger("Attack");
        }


    }

   
}

    

    
