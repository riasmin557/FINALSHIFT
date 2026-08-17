using UnityEngine;

public class DeteccaoPorta2 : MonoBehaviour
{
    public Transform player;
    public Transform zumbi;

    public Transform vidroD;
    public Transform vidroE;

    public float distanciaA= 3f;
    public float velocid= 1f;
    public float distanciaM= 1f;

    private Vector3 posIVidroD;
    private Vector3 posIVidroE;

    private bool ativacao = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posIVidroD = vidroD.position;
        posIVidroE = vidroE.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaJogador = Vector3.Distance(player.position, transform.position);
        float distanciaInimigo = Vector3.Distance(zumbi.position, transform.position);

        bool ativacao = (distanciaJogador <= distanciaA || distanciaInimigo <= distanciaA);

        Vector3 destino1 = ativacao ? posIVidroD + Vector3.left * distanciaM : posIVidroD;
        Vector3 destino2 = ativacao ? posIVidroE + Vector3.right * distanciaM : posIVidroE;

        vidroD.position = Vector3.MoveTowards(vidroD.position, destino1, velocid * Time.deltaTime);
        vidroE.position = Vector3.MoveTowards(vidroE.position, destino2, velocid * Time.deltaTime);
    }
}
