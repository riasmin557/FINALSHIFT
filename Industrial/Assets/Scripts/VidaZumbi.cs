using UnityEngine;

public class VidaZumbi : MonoBehaviour
{
    public float vidaMax = 100f;
    public float vidaAtual;

    void Start()
    {
        vidaAtual = vidaMax;
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
        Destroy(gameObject);
    }
}
