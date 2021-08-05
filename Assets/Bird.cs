using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
   
    public GameObject expFX;
    public Text scoreText;
    public static int score = 0;
    public GameObject environment;
    public static int speed = 5;
    public Text speedText;
    public Text finalScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score;

        speedText.text = "SPEED: " + SpeedManager.getSpeed();

        speed = SpeedManager.getSpeed();

        // Push the bird upwards with a force of 200 when  Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetComponent<Rigidbody2D>().AddRelativeForce(
                Vector3.up * 200
                );
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground") || collision.transform.CompareTag("Tree"))
        {
            finalScore.text = "Score: " + score;

            GameObject newExplosion;
            newExplosion = Instantiate(expFX, transform.position, transform.rotation);
            
            Destroy(newExplosion, 1);

            Cam.panSpeed = 0;
            
            Destroy(transform.gameObject);
            print("Player died");
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Coin"))
        {
            score = score + 1;
            Destroy(other.transform.gameObject);
        }
        if (other.transform.name.Equals("GenerateMoreLevel"))
        {
            SpeedManager.incrementSpeed();
            GameObject currEnv = Instantiate(environment, new Vector3(transform.position.x + 37, (float) -19.2), transform.rotation);
        }
    }
}
