using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5;
    public KeyCode InputKeyUp = KeyCode.W;
    public KeyCode InputKeyDown = KeyCode.S;

    private void Update()
    {
        float movement = ProcessInput();
        Move(movement);
        ClampPositionToScreen();
    }

    private float ProcessInput()
    {
        float movement = 0;

        if (Input.GetKey(InputKeyUp))
        {
            movement = 1;
        }
        else if (Input.GetKey(InputKeyDown))
        {
            movement = -1;
        }
        
        return movement;
    }
    
    private void Move(float movement)
    {
        transform.Translate(0, movement * speed * Time.deltaTime, 0);
        
    }

    private void ClampPositionToScreen()
    {
        float maxPositionY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float minPositionY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, minPositionY + 1, maxPositionY - 1);
        transform.position = position;
    }
}
