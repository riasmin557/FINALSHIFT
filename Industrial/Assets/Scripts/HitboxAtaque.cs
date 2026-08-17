using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HitboxAtaque : MonoBehaviour
{
    public bool jogadorNaArea = false;

    public VidaPlayer jogador;
    public HitboxAtaque hitbox;
    public Transform hitboxTransform;

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
           jogadorNaArea=true;

        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorNaArea=false;
        }
    }

    public void Dano()
    {
        if (Physics.OverlapBox(hitboxTransform.position,new Vector3(1,1,1),).Length>0)
        {
            jogador.ReceberDano(10f);
            Debug.Log("Você foi atacado!");
        }

    }

   
}


