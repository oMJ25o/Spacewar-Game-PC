using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRb;

    [SerializeField]
    private int speed;
    public int Speed // Bullet Movement Speed Get Property
    {
        get { return speed; }
    }

    [HideInInspector] public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.Find("Weapon Equipped");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // Destroy this game object when it reaches outside the player's screen
    }
}
