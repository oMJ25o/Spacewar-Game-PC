using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Make sure look direction function will not run unless the player pressed A/D input actions
        LookDirection();
    }

    // Player change look direction based on the A/D input actions
    private void LookDirection()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to world coordinates (2D)
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0f));

        if (worldMousePosition.x < transform.position.x && GetComponent<SpriteRenderer>().flipX != true)
        {
            // Player will look to the left
            GetComponent<SpriteRenderer>().flipX = true;
            EventController.current.PlayerRotate();
        }
        else if (worldMousePosition.x > transform.position.x && GetComponent<SpriteRenderer>().flipX != false)
        {
            // Player will look to the right
            GetComponent<SpriteRenderer>().flipX = false;
            EventController.current.PlayerRotate();
        }
    }
}
