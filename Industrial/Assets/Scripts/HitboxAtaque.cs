using UnityEngine;

public class HitboxAtaque : MonoBehaviour
{
    public bool jogadorNaArea = false;

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
}
