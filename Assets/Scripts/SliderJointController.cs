using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderJointController : MonoBehaviour
{
    [SerializeField] private SliderJoint2D[] platforms;
    private bool upperLimit_firstPlatform;

    private bool upperLimit_secondPlatform;

    private bool upperLimit_thirdPlatform;
    private void Update()       
    {
        StartCoroutine(ChangingMotorSpeed());
    }
    private IEnumerator ChangingMotorSpeed()
    {
        //1st platform
        if(!upperLimit_firstPlatform)
        {
            JointMotor2D firstPlatformMotor = platforms[0].motor;
            firstPlatformMotor.motorSpeed = 2;
            platforms[0].motor = firstPlatformMotor;
            if(platforms[0].limitState == JointLimitState2D.UpperLimit)
            {
                upperLimit_firstPlatform = true;
            }
        }
        else if(upperLimit_firstPlatform)
        {
            JointMotor2D firstPlatformMotor = platforms[0].motor;
            firstPlatformMotor.motorSpeed = -2;
            platforms[0].motor = firstPlatformMotor;
            if(platforms[0].limitState == JointLimitState2D.LowerLimit)
            {
                upperLimit_firstPlatform = false;
            }
        }
        yield return new WaitForSeconds(1);
        //2nd platform
        if(!upperLimit_secondPlatform)
        {
            JointMotor2D secondPlatformMotor = platforms[1].motor;
            secondPlatformMotor.motorSpeed = 2;
            platforms[1].motor = secondPlatformMotor;
            if(platforms[1].limitState == JointLimitState2D.UpperLimit)
            {
                upperLimit_secondPlatform = true;
            }   
        }
        else if(upperLimit_secondPlatform)
        {
            JointMotor2D secondPlatformMotor = platforms[1].motor;
            secondPlatformMotor.motorSpeed = -2;
            platforms[1].motor = secondPlatformMotor;
            if(platforms[1].limitState == JointLimitState2D.LowerLimit)
            {
                upperLimit_secondPlatform = false;
            }
        }
        yield return new WaitForSeconds(1);
        //3rd platform
        if(!upperLimit_thirdPlatform)
        {
            JointMotor2D thirdPlatformMotor = platforms[2].motor;
            thirdPlatformMotor.motorSpeed = 2;
            platforms[2].motor = thirdPlatformMotor;
            if(platforms[2].limitState == JointLimitState2D.UpperLimit)
            {
                upperLimit_thirdPlatform = true;
            }   
        }
        else if(upperLimit_thirdPlatform)
        {
            JointMotor2D thirdPlatformMotor = platforms[2].motor;
            thirdPlatformMotor.motorSpeed = -2;
            platforms[2].motor = thirdPlatformMotor;
            if(platforms[2].limitState == JointLimitState2D.LowerLimit)
            {
                upperLimit_thirdPlatform = false;
            }
        }
        yield return new WaitForSeconds(1);
    }
}
