using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<SliderJoint2D> enemySliders;
    [SerializeField] private float motorSpeed = 1.5f;
    [SerializeField] private List<Animator> enemyAnimes;
    [SerializeField] private List<GameObject> enemyObjects;
    private List<bool> _isMovingList = new List<bool> { false, false };
    private void Update()
    {
        StartPatrolAnimation();
        Patrol();
    }
    private void Patrol()
    {
        //1st enemy patrol
        if (enemySliders[0].limitState == JointLimitState2D.LowerLimit)
        {
            GoLeft(0);
            Flip(0);
            _isMovingList[0] = true;
        }
        else if (enemySliders[0].limitState == JointLimitState2D.UpperLimit)
        {
            GoRight(0);
            Flip(0);
            _isMovingList[1] = true;
        }
        //2nd enemy patrol
        if (enemySliders[1].limitState == JointLimitState2D.LowerLimit)
        {
            GoLeft(1);
            Flip(1);
            _isMovingList[0] = true;
        }
        else if (enemySliders[1].limitState == JointLimitState2D.UpperLimit)
        {
            GoRight(1);
            Flip(1);
            _isMovingList[1] = true;
        }
        //3ed enemy patrol
        if (enemySliders[2].limitState == JointLimitState2D.LowerLimit)
        {
            GoLeft(2);
            Flip(2);
            _isMovingList[0] = true;
        }
        else if (enemySliders[2].limitState == JointLimitState2D.UpperLimit)
        {
            GoRight(2);
            Flip(2);
            _isMovingList[1] = true;
        }
    }
    private void GoLeft(int IndexOfEnemy)
    {
        JointMotor2D jointMotor = enemySliders[IndexOfEnemy].motor;
        jointMotor.motorSpeed = motorSpeed;
        enemySliders[IndexOfEnemy].motor = jointMotor;
    }
    private void GoRight(int indexOfEnemy)
    {
        JointMotor2D jointMotor = enemySliders[indexOfEnemy].motor;
        jointMotor.motorSpeed = -motorSpeed;
        enemySliders[indexOfEnemy].motor = jointMotor;
    }
    private void Flip(int indexOfEnemy)
    {
        if (_isMovingList[0])
        {
            enemyObjects[indexOfEnemy].GetComponent<SpriteRenderer>().flipX = false;
            _isMovingList[0] = false;
        }
        else if (_isMovingList[1])
        {
            enemyObjects[indexOfEnemy].GetComponent<SpriteRenderer>().flipX = true;
            _isMovingList[1] = false;
        }
    }
    private void StartPatrolAnimation()
    {
        foreach (Animator enemyAnime in enemyAnimes)
        {
            enemyAnime.SetBool("patrol", true);
        }
    }
}
