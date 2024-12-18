using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameController gameController;
    public string typeBall = "NORMAL"; // Xác định bóng x2 điểm
    private void Start() {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player"))
        {
            if (typeBall == "DOUBLE")
            {
                gameController.ActivateDoubleScore(); // Kích hoạt hiệu ứng x2 điểm
            }
            if (typeBall == "NORMAL") {
                gameController.IncrementScore();
            }
            if (typeBall == "DESTROY")
            {
                gameController.DecrementScore();
            }


            Destroy(gameObject);
            Debug.Log("Va cham voi player");
        }
    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("DeathZone"))
        {
            
            if (typeBall == "NORMAL")
            {
                gameController.SetStateIsGameOver(true);
                Debug.Log("Va cham deathzone, Game Over");
            }
            Destroy(gameObject); 
        }
    }
}
