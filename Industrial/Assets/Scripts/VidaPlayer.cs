using UnityEngine;
using UnityEngine.UI;


public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;

    public Image barraVida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarra();
    }

    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
        {
            vidaAtual = 0;
        }

        AtualizarBarra();
    }

    void AtualizarBarra()
    {
        barraVida.fillAmount = vidaAtual / vidaMaxima;
    }
}

    
