using System.Collections;
using UnityEngine;

public class SliderJointController : MonoBehaviour
{
    [SerializeField] private SliderJoint2D[] platforms;
    [SerializeField] private float motorSpeed = 2f;

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
            SetMotorSpeed(1);
            if(platforms[0].limitState == JointLimitState2D.UpperLimit)
            {
                upperLimit_firstPlatform = true;
            }
        }
        else if(upperLimit_firstPlatform)
        {
            SetNegativeMotorSpeed(1);
            if(platforms[0].limitState == JointLimitState2D.LowerLimit)
            {
                upperLimit_firstPlatform = false;
            }
        }
        yield return new WaitForSeconds(1.2f);
        //2nd platform
        if(!upperLimit_secondPlatform)
        {
            SetMotorSpeed(2);
            if(platforms[1].limitState == JointLimitState2D.UpperLimit)
            {
                upperLimit_secondPlatform = true;
            }   
        }
        else if(upperLimit_secondPlatform)
        {
            SetNegativeMotorSpeed(2);
            if(platforms[1].limitState == JointLimitState2D.LowerLimit)
            {
                upperLimit_secondPlatform = false;
            }
        }
        yield return new WaitForSeconds(0.48f);
    }
    private void SetMotorSpeed(int indexOfPlatform)
    {
        JointMotor2D jointMotor = platforms[indexOfPlatform - 1].motor;
        jointMotor.motorSpeed = motorSpeed;
        platforms[indexOfPlatform - 1].motor = jointMotor;
    }
    private void SetNegativeMotorSpeed(int indexOfPlatform)
    {
        JointMotor2D jointMotor = platforms[indexOfPlatform - 1].motor;
        jointMotor.motorSpeed = -motorSpeed ;
        platforms[indexOfPlatform - 1].motor = jointMotor;
    }

}
