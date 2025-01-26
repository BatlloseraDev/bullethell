using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider; 
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScooreKeeper scooreKeeper;


    void Awake()
    {
        scooreKeeper = FindObjectOfType<ScooreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

   
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scooreKeeper.GetScore().ToString("000000000");
    }
}
