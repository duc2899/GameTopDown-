using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float speed;
    float xDirection;
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameController.GetStateIsGameOver() && gameController.GetStartGame()) { 
            xDirection = Input.GetAxisRaw("Horizontal");
            float moveSteps = xDirection * speed * Time.deltaTime;
            // get limit x screen 
            float screenLimitX = Camera.main.orthographicSize * Camera.main.aspect;
            //limit for line
            float newXDirection = Mathf.Clamp(transform.position.x + moveSteps, -screenLimitX, screenLimitX);
       
            transform.position = new Vector3(newXDirection, transform.position.y, 0);
        }
       
    }
}
