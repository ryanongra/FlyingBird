using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{

    public static int speed = 5;

    public static int getSpeed()
    {
        return speed;
    }

    public static void incrementSpeed()
    {
        speed += 5;
    }

    public static void resetSpeed()
    {
        speed = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
