using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TipForRepairLadder : MonoBehaviour
{
    [SerializeField] private GameObject showGuideIcon;
    private bool _triggerForGuide;
    [Space]
    [SerializeField] private GameObject[] oldLadder;
    [Space]
    [SerializeField] private GameObject[] newLadder;
    [Header("Count of killed enemies")]
    [SerializeField] private EnemyDie enemyDie;
    private void Update()
    {
        ShowTipsAboutRepair();

        RepairTheLedder();
    }
    private void RepairTheLedder()
    {
        if (EnemyDie.killedEnemiesCount >= 3)
        {
            oldLadder[0].SetActive(false);
            oldLadder[1].SetActive(false);

            newLadder[0].SetActive(true);
            newLadder[1].SetActive(true);
        }
    }
    private void ShowTipsAboutRepair()
    {
        if (_triggerForGuide)
        {
            showGuideIcon.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerOfRepairGuide"))
        {
            _triggerForGuide = true;
        }
    }
}
