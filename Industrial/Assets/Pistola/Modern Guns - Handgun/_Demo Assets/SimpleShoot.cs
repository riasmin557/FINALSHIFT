using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;

    [Header("Location Refrences")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Specify time to destory the casing object")] [SerializeField] private float destroyTimer = 2f;
    [Tooltip("Bullet Speed")] [SerializeField] private float shotPower = 500f;
    [Tooltip("Casing Ejection Speed")] [SerializeField] private float ejectPower = 150f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;

    [SerializeField] private Camera playerCamera;


    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gunAnimator.SetTrigger("Fire");
        }
    }


    //This function creates the bullet behavior
    void Shoot()
    {
        // Som do tiro
         if (audioSource != null && shootSound != null)
        { 
            audioSource.PlayOneShot(shootSound); 
        } 
         
         // Efeito de disparo
         if (muzzleFlashPrefab)
        {
            GameObject tempFlash; tempFlash = Instantiate( muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation );
            Destroy(tempFlash, destroyTimer);
        }
         
         // Ray começa no centro da câmera
         Ray ray = playerCamera.ViewportPointToRay( new Vector3(0.5f, 0.5f, 0) );
        
        // Verifica o que a mira atingiu
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
        {
            // Só permite dano no Layer "Inimigo"
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("inimigo"))
            {
                VidaZumbi vidaZumbi = hit.collider.GetComponentInParent<VidaZumbi>();

                if (vidaZumbi != null) 
                {
                    vidaZumbi.ReceberAtaque(25f);
                }
            } 
            Debug.Log("Acertou: " + hit.collider.gameObject.name); 
        }

    }

    //This function creates a casing at the ejection slot
    void CasingRelease()
    {
        //Cancels function if ejection slot hasn't been set or there's no casing
        if (!casingExitLocation || !casingPrefab)
        { return; }

        //Create the casing
        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        //Add force on casing to push it out
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        //Add torque to make casing spin in random direction
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        //Destroy casing after X seconds
        Destroy(tempCasing, destroyTimer);
    }


    

}
