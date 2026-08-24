using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class VidaPlayer : MonoBehaviour
{
    public float vidaMaxima = 100f;
    public float vidaAtual;

    public Image barraVida;

    public GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarra();

        gameOver.SetActive(false);
    }

    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual < 0)
        {
            vidaAtual = 0;
        }

        AtualizarBarra();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void AtualizarBarra()
    {
        barraVida.fillAmount = vidaAtual / vidaMaxima;
    }

    void Morrer()
    {
        Debug.Log("O jogador morreu!");

        gameOver.SetActive(true);

        
    }

    public void ReiniciarJogo()
    {
       

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Botao apertado");
    }
}

    
