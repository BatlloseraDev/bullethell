using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 0.1f; 
    Vector2 rawInput; 


    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBot;

    Vector2 minBounds;
    Vector2 maxBounds;
    
    Shooter shooter;

    void Awake() 
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }



    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1)); 
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos= new Vector2(); 
        newPos.x = Mathf.Clamp(transform.position.x +delta.x, minBounds.x +paddingLeft,maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y +delta.y, minBounds.y +paddingBot,maxBounds.y -paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
       rawInput = value.Get<Vector2>();
       
    }

    void OnFire(InputValue value)
    {
        if(shooter !=null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
