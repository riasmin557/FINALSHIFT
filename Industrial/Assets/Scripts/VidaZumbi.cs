using UnityEngine;

public class VidaZumbi : MonoBehaviour
{
    public float vidaMax = 100f;
    public float vidaAtual;

    void Start()
    {
        vidaAtual = vidaMax;
    }

    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;

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
