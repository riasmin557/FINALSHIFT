using UnityEngine;

public class DeteccaoPorta : MonoBehaviour
{
    public Transform jogador;
    public Transform inimigo;

    public Transform blocoD;
    public Transform blocoE;

    public float distanciaAtivacao = 3f;
    public float velocidade = 2f;
    public float distanciaMovimento = 2f;

    private Vector3 posInicialBlocoD;
    private Vector3 posInicialBlocoE;

    private bool ativado=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posInicialBlocoD = blocoD.position;
        posInicialBlocoE = blocoE.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaJogador= Vector3.Distance(jogador.position,transform.position);
        float distanciaInimigo= Vector3.Distance(inimigo.position, transform.position);

        bool ativado= (distanciaJogador<=distanciaAtivacao|| distanciaInimigo<=distanciaAtivacao);

        Vector3 destino1 = ativado ? posInicialBlocoD + Vector3.forward * distanciaMovimento : posInicialBlocoD;
        Vector3 destino2 = ativado ? posInicialBlocoE + Vector3.back * distanciaMovimento : posInicialBlocoE;

        blocoD.position= Vector3.MoveTowards(blocoD.position,destino1,velocidade*Time.deltaTime);
        blocoE.position = Vector3.MoveTowards(blocoE.position, destino2, velocidade * Time.deltaTime);
    }
}
