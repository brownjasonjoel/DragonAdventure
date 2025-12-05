using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Arrows;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip arrowSound;

    private void attack()
    {

        cooldownTimer = 0;

        SoundManager.instance.PlaySound(arrowSound);
        Arrows[FindArrows()].transform.position = firePoint.position;
        Arrows[FindArrows()].GetComponent<EnemyProjectile>().ActivateProjectile();

    }

    private int FindArrows()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            if (!Arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= attackCoolDown)
        {
            attack();

        }
        
    }

}
