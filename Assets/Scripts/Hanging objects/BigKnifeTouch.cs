using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BigKnifeTouch : MonoBehaviour
{
    private HangingObstacleComponent hangingObstacles;
    private void Awake()
    {
        hangingObstacles = GetComponentInParent<HangingObstacleComponent>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hangingObstacles.character = true;
        }
    }
}
