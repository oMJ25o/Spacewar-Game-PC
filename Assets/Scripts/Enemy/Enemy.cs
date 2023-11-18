using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    public int MaxHp
    {
        get { return maxHp; }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Max Hp cannot be lower than or equal to 0");
            }
            else
            {
                maxHp = value;
            }
        }
    }
    public int CurrentHp
    {
        get { return currentHp; }
        set
        {
            if (value <= 0 && value > maxHp)
            {
                Debug.Log("Enemies' current hp cannot be lower than or equal to 0 and cannot be higher than max hp");
            }
            else
            {
                currentHp = value;
            }
        }
    }
    public int Str
    {
        get { return str; }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Enemies' Strength cannot be lower than or equal to 0");
            }
            else
            {
                str = value;
            }
        }
    }

    private int currentHp;
    private int maxHp;
    private int str;

    // Start is called before the first frame update
    void Start()
    {
        SetupEnemy();
    }

    private void SetupEnemy()
    {
        EventController.current.onEnemyHit += TakeDamage; // Subscribe the take damage function to the on enemy hit event

        MaxHp = enemyData.hp;
        CurrentHp = maxHp;
        Str = enemyData.str;
    }

    private void TakeDamage(int dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            EventController.current.onEnemyHit -= TakeDamage; // Unsubscribe function to the event when the enemy dies
            Destroy(gameObject);
        }
    }

}
