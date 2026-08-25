using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class VidaZumbi : MonoBehaviour
{
    public float vidaMax = 100f;
    public float vidaAtual;

    private Vector3 posicaoInicial;

    private Renderer[] renderizadores;
    private Collider[] collidersZumbi;
    private NavMeshAgent agent;


    void Start()
    {
        vidaAtual = vidaMax;

        // Guarda a posição inicial
        posicaoInicial = transform.position;

        // Pega todas as partes visuais do zumbi
        renderizadores = GetComponentsInChildren<Renderer>();

        // Pega todos os Colliders
        collidersZumbi = GetComponentsInChildren<Collider>();

        // Pega o NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    public void ReceberAtaque(float ataque)
    {
        vidaAtual -= ataque;

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        // Desativa a aparência do zumbi
        foreach (Renderer renderizador in renderizadores)
        {
            renderizador.enabled = false;
        }

        // Desativa os Colliders
        foreach (Collider col in collidersZumbi)
        {
            col.enabled = false;
        }

        // Para o movimento
        if (agent != null)
        {
            agent.enabled = false;
        }

        // Começa a contagem para renascer
        StartCoroutine(Renascer());
    }

    IEnumerator Renascer()
    {
        // Espera 30 segundos
        yield return new WaitForSeconds(30f);

        // Volta para a posição inicial
        transform.position = posicaoInicial;

        vidaAtual= vidaMax;

        // Ativa novamente a aparência
        foreach (Renderer renderizador in renderizadores)
        {
            renderizador.enabled = true;
        }

        // Ativa novamente os Colliders
        foreach (Collider col in collidersZumbi)
        {
            col.enabled = true;
        }

        // Ativa o movimento novamente
        if (agent != null)
        {
            agent.enabled = true;
        }

       
    }

    
}
