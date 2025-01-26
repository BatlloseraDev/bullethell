using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScooreKeeper scooreKeeper; 
    void Awake()
    { 
        scooreKeeper = FindObjectOfType<ScooreKeeper>();
    }
    void Start()
    {
        scoreText.text = "Tu puntuashao: \n" + scooreKeeper.GetScore(); 
    }

}
