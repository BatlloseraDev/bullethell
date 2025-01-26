using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   [Header("Shooting")]
   [SerializeField] AudioClip shootingClip;
   [SerializeField] [Range(0f,1f)] float shootingVolumen = 1f; 
    
   [Header("Damage")]
   [SerializeField] AudioClip damageClip;
   [SerializeField] [Range(0f,1f)] float damageVolumen = 1f; 

    static AudioPlayer instance; 
   
    void Awake() 
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {

        if(instance!=null)
        {
            gameObject.SetActive(false); 
            Destroy(gameObject);
        }
        else 
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }

        /*int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instanceCount >1) 
        {   
            gameObject.SetActive(false); 
            Destroy(gameObject); 
        }
        else 
        {
            DontDestroyOnLoad(gameObject); 
        }*/
    }
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolumen); 
    }
    public void PlayDamageClip()
    {
       PlayClip(damageClip, damageVolumen); 
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip!=null)
        {
            Vector3 cameraPos = Camera.main.transform.position; 
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume); 
        }
    }

}
