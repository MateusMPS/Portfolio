using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {

    public Rigidbody2D asteroidRB;
    public float impulsoX = 50.0f;
    public float impulsoY = 30.0f;

    // Use this for initialization
    void Start () {

        asteroidRB = GetComponent<Rigidbody2D>();
        asteroidRB.AddForce(new Vector2(Random.Range(-impulsoX, impulsoX), Random.Range(-impulsoY, 0.0f)));

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Destroyer"))
        {
            Destroy(this.gameObject);
        }
    }

}
