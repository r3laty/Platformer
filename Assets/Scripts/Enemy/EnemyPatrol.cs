using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private List<SliderJoint2D> enemies;
    [SerializeField] private float motorSpeed = 1.5f;
    private void Update()
    {
        Patrol();
    }
    private void Patrol()
    {
        //1st enemy patrol
        if (enemies[0].limitState == JointLimitState2D.LowerLimit)
        {
            GoLeft(0); //1.5
        }
        else if (enemies[0].limitState == JointLimitState2D.UpperLimit)
        {
            GoRight(0); //-1.5
        }
        //2nd enemy patrol
        if (enemies[1].limitState == JointLimitState2D.LowerLimit)
        {
            GoLeft(1);
        }
        else if (enemies[1].limitState == JointLimitState2D.UpperLimit)
        {
            GoRight(1);
        }
        //3ed enemy patrol
        if (enemies[2].limitState == JointLimitState2D.LowerLimit)
        {
            GoLeft(2);
        }
        else if (enemies[2].limitState == JointLimitState2D.UpperLimit)
        {
            GoRight(2);
        }
    }
    private void GoLeft(int IndexOfEnemy)
    {
        JointMotor2D jointMotor = enemies[IndexOfEnemy].motor;
        jointMotor.motorSpeed = motorSpeed;
        enemies[IndexOfEnemy].motor = jointMotor;
    }
    private void GoRight(int indexOfEnemy)
    {
        JointMotor2D jointMotor = enemies[indexOfEnemy].motor;
        jointMotor.motorSpeed = -motorSpeed;
        enemies[indexOfEnemy].motor = jointMotor;
    }
}
