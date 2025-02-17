using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer; 
    [SerializeField] int health = 50;
    [SerializeField] int score = 50; 
    [SerializeField] ParticleSystem hitEffect; 

    [SerializeField] bool applyCameraShake; 
    CameraShake cameraShake; 
    AudioPlayer audioPlayer;
    ScooreKeeper scooreKeeper; 
    LevelManager levelManager; 
    void Awake() 
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scooreKeeper = FindObjectOfType<ScooreKeeper>();    
        levelManager = FindObjectOfType<LevelManager>(); 
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer= other.GetComponent<DamageDealer>(); 

        if(damageDealer !=null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect(); 
            audioPlayer.PlayDamageClip(); 
            ShakeCamera();
            damageDealer.Hit(); 
        }        
    }

    public int GetHealth()
    {
        return health; 
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if(health<=0)
        {
            Die();
        }
    }

    private void Die()
    {

        if(!isPlayer)
        {
            scooreKeeper.ModifyScore(score); 
        }
        else
        {
            levelManager.LoadGameOver(); 
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect !=null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity); 
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax); 
        }
    }

    void ShakeCamera()
    {
        if(cameraShake !=null && applyCameraShake)
        {
            cameraShake.Play(); 
        }
    }
}
