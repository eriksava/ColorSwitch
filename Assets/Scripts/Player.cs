using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    string currentColor;

    public float speedJump = 10f;

    public Rigidbody2D circle;

    public SpriteRenderer sr;

    public GameObject[] obsticle;
    public GameObject colorChanger;

    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;

    public static int score = 0;

    public Text scoreText;


	// Use this for initialization
	void Start () {

        SetRandomColor();


	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetMouseButton(0) || Input.GetButtonDown("Jump")){

            circle.velocity = Vector2.up * speedJump;

        }

        scoreText.text = score.ToString();

	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Scored"){

            score++;
            Destroy(collision.gameObject);
            int randomNumber = Random.Range(0, 2);
            if(randomNumber == 0){
                Instantiate(obsticle[0], new Vector2(transform.position.x, transform.position.y + 13f), transform.rotation);
            }
            else
            {
                Instantiate(obsticle[1], new Vector2(transform.position.x, transform.position.y + 12f), transform.rotation);
            }

            return;
        }




        if(collision.tag == "ColorChanger"){

            SetRandomColor();
            Destroy(collision.gameObject);
            Instantiate(colorChanger, new Vector2(transform.position.x, transform.position.y + 13f), transform.rotation);
            return;
        }



        if(collision.tag != currentColor){
            Debug.Log("You died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }
    }

    void SetRandomColor(){

        int rand = Random.Range(0, 4);

        switch(rand){

            case 0:
                currentColor = "Blue";
                sr.color = blue;
                break;

            case 1:
                currentColor = "Yellow";
                sr.color = yellow;

                break;
            case 2:
                currentColor = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;


        }
    }

}
