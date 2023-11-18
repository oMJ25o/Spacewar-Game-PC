using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;
    private int dmg;

    public int Dmg
    {
        get { return dmg; }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Bullet's Damage cannot be lower than or equal to 0");
            }
            else
            {
                dmg = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupBullet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetupBullet()
    {
        Dmg = bulletData.dmg;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If it collides with an obstacle, destroy the bullet
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy")) // If its an enemy, damage the enemy and destroy the bullet
        {
            EventController.current.EnemyHit(dmg);
            Destroy(gameObject);
        }
    }
}
