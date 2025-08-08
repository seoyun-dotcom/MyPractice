using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D leftStickRb;
    public Rigidbody2D rightStickRb;

    public int totalScore;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            leftStickRb.AddTorque(30f);
        else
            leftStickRb.AddTorque(-25f);

        if (Input.GetKey(KeyCode.RightArrow))
            rightStickRb.AddTorque(-30f);
        else
            rightStickRb.AddTorque(25f);
    }
    
}
