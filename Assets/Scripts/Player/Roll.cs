using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    [SerializeField] private int rollSpeedValue;
    private GameObject weaponParent;
    // Start is called before the first frame update
    void Start()
    {
        EventController.current.onPlayerRoll += PlayerRoll; //Subscribes the PlayerRoll function to the onPlayerRoll event
        weaponParent = GameObject.Find("Weapon Equipped");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventController.current.PlayerRoll(); // Triggers the PlayerRoll event on the Event Controller Component
        }
    }

    // Roll Function subsribed to the onPlayerRoll Event
    private void PlayerRoll()
    {
        gameObject.GetComponent<Movement>().RollSpeed = rollSpeedValue;
        gameObject.GetComponent<Animator>().SetBool("isRollPressed", true); // Sets the bool parameter of the animation to run the roll animation
        weaponParent.SetActive(false);
    }

    // Setting all the values back from normal after roll animation
    private void onRollFinish()
    {
        gameObject.GetComponent<Movement>().RollSpeed = 1;
        gameObject.GetComponent<Animator>().SetBool("isRollPressed", false); // Sets the bool parameter of the animation to run back to the idle animation
        weaponParent.SetActive(true);
    }

}
