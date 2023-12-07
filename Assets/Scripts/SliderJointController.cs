using System.Collections;
using UnityEngine;

public class SliderJointController : MonoBehaviour
{
    [SerializeField] private SliderJoint2D[] platforms;
    [SerializeField] private float motorSpeed = 2f;

    private bool _upperLimitFirstPlatform;
    private bool _upperLimitSecondPlatform;


    private void Update()       
    {
        StartCoroutine(ChangingMotorSpeed());
    }
    private IEnumerator ChangingMotorSpeed()
    {
        //1st platform
        if(!_upperLimitFirstPlatform)
        {
            SetMotorSpeed(1);
            if(platforms[0].limitState == JointLimitState2D.UpperLimit)
            {
                _upperLimitFirstPlatform = true;
            }
        }
        else if(_upperLimitFirstPlatform)
        {
            SetNegativeMotorSpeed(1);
            if(platforms[0].limitState == JointLimitState2D.LowerLimit)
            {
                _upperLimitFirstPlatform = false;
            }
        }
        yield return new WaitForSeconds(1.2f);
        //2nd platform
        if(!_upperLimitSecondPlatform)
        {
            SetMotorSpeed(2);
            if(platforms[1].limitState == JointLimitState2D.UpperLimit)
            {
                _upperLimitSecondPlatform = true;
            }   
        }
        else if(_upperLimitSecondPlatform)
        {
            SetNegativeMotorSpeed(2);
            if(platforms[1].limitState == JointLimitState2D.LowerLimit)
            {
                _upperLimitSecondPlatform = false;
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
