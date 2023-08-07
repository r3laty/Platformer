using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Assertions.Must;

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
            JointMotor2D firstHingeObj = hingeObjects[0].motor;
            firstHingeObj.motorSpeed = motorSpeed;
            hingeObjects[0].motor = firstHingeObj;
        }
        else if (hingeObjects[0].limitState == JointLimitState2D.UpperLimit)
        {
            JointMotor2D firstHingeObj = hingeObjects[0].motor;
            firstHingeObj.motorSpeed = -motorSpeed;
            hingeObjects[0].motor = firstHingeObj;
        }
        //second object
        if (hingeObjects[1].limitState == JointLimitState2D.LowerLimit)
        {
            JointMotor2D secondHingeObj = hingeObjects[1].motor;
            secondHingeObj.motorSpeed = motorSpeed;
            hingeObjects[1].motor = secondHingeObj;
        }
        else if (hingeObjects[1].limitState == JointLimitState2D.UpperLimit)
        {
            JointMotor2D secondHingeObj = hingeObjects[1].motor;
            secondHingeObj.motorSpeed = -motorSpeed;
            hingeObjects[1].motor = secondHingeObj;
        }
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
