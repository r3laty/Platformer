using System.Collections.Generic;
using UnityEngine;

public class HangingObstacleComponent : MonoBehaviour
{
    [SerializeField] private SliderJoint2D sliderObject;
    [SerializeField] private float motorSpeed = 150;
    [SerializeField] private List<HingeJoint2D> hingeObjects;
    [SerializeField] private GameObject mainCharacter;
    [HideInInspector] public bool character;
    private void Update()
    {
        CouldCharacterGo();
        HingeJointObjects();
        SliderJointObject();
    }
    private void CouldCharacterGo()
    {
        if(character)
        {
            Destroy(mainCharacter);
        }
    }
    private void HingeJointObjects()
    {
        //first object
        if (hingeObjects[0].limitState == JointLimitState2D.LowerLimit)
        {
            SetMotorSpeed(1);
        }
        else if (hingeObjects[0].limitState == JointLimitState2D.UpperLimit)
        {
            SetNegativeMotorSpeed(1);
        }
        //second object
        if (hingeObjects[1].limitState == JointLimitState2D.LowerLimit)
        {
            SetMotorSpeed(2);
        }
        else if (hingeObjects[1].limitState == JointLimitState2D.UpperLimit)
        {
            SetNegativeMotorSpeed(2);
        }
    }
    private void SetMotorSpeed(int indexOfItem)
    {
        JointMotor2D jointMotor = hingeObjects[indexOfItem - 1].motor;
        jointMotor.motorSpeed = motorSpeed;
        hingeObjects[indexOfItem - 1].motor = jointMotor;
    }
    private void SetNegativeMotorSpeed(int indexOfItem)
    {
        JointMotor2D jointMotor = hingeObjects[indexOfItem - 1].motor;
        jointMotor.motorSpeed = -motorSpeed;
        hingeObjects[indexOfItem - 1].motor = jointMotor;
    }
    private void SliderJointObject()
    {
        RaycastHit2D groundHit = Physics2D.Raycast(sliderObject.transform.position, Vector2.down, 0.5f);
        RaycastHit2D roofHit = Physics2D.Raycast(sliderObject.transform.position, Vector2.up, 0.5f);
        
        if (groundHit.collider != null)
        {
            sliderObject.useMotor = true;
        }
        else if(roofHit.collider != null)
        {
            sliderObject.useMotor = false;
        }
    }
}
