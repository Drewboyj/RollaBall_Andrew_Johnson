using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
      
   
    private Rigidbody rb;
    private int count;
    private int lives;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lives = 3;
        count = 0;
        SetlivesText();
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
           
                  
          
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Bad Pick Up"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetlivesText();
        }

        if (count == 12) 
{
    transform.position = new Vector3(35.0f,.0f,.0f); 
}
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win!";
            if (gameObject.tag == "Player")
            {
                Destroy(obj: gameObject);
            }
        }
    }

    void SetlivesText()
    {
        livesText.text = "lives: " + lives.ToString();
        bool v = lives <= 0;
        if (v)
        {
            winText.text = "You Lose.";
            if (gameObject.tag == "Player")
            {
                Destroy(obj: gameObject);
            }

        }


    }

}
