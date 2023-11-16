using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRb;

    [SerializeField]
    private int speed;

    private GameObject Weapon;
    public int Speed // Bullet Movement Speed Get Property
    {
        get { return speed; }
    }


    // Start is called before the first frame update
    void Start()
    {
        Movement();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Movement()
    {
        Weapon = GameObject.Find("Weapon");
        bulletRb.AddForce(Weapon.transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
