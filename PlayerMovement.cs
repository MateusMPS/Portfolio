using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstronautMovement : MonoBehaviour {

    public float thrustForce = 2.0f;

    private Rigidbody2D rb;
    public GameObject player;
    private Vector2 posicMouse;
    private Vector2 posicPlayer;
    private Vector2 movResultante;

    public GameObject vida0, vida1, vida2, vida3;

    public GameObject[] vida;
        

    public int playerLife;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        playerLife = 3;

        vida = new GameObject[4];
        vida[0] = vida0;
        vida[1] = vida1;
        vida[2] = vida2;
        vida[3] = vida3;



    }
	
	// Update is called once per frame
	void Update () {

        posicPlayer = player.transform.position;
        lifeDisplay(playerLife);


        if (Input.GetMouseButton(0))
        {
            posicMouse = Camera.main.ScreenPointToRay(Input.mousePosition).GetPoint(0);
            Debug.Log(posicMouse);
            movResultante = posicPlayer - posicMouse;

            rb.AddForce(movResultante * thrustForce);
        }

        if(playerLife <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerLife--;
        }
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            playerLife = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroyer"))
        {
            playerLife = 0;
        }
    }

    public void lifeDisplay(int x)
    {
        vida[x].SetActive(true);
    }
}

