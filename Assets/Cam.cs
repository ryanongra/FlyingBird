using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cam : MonoBehaviour
{
    public static float panSpeed = 5;

    public Canvas deadCanvas;

    public Text finalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        deadCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (panSpeed == 0)
        {
            deadCanvas.gameObject.SetActive(true);
            finalSpeed.text = "Speed: " + SpeedManager.getSpeed();

        }
        else
        {
            panSpeed = SpeedManager.getSpeed();
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
    }

    public void RestartGame()
    {
        SpeedManager.resetSpeed();
        panSpeed = SpeedManager.getSpeed();
        Bird.speed = SpeedManager.getSpeed();
        Bird.score = 0;

        SceneManager.LoadScene(0);
    }
}
