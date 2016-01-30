using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {
    GameObject collidedWith = null;
	// Use this for initialization
	void Start () {
        
	
	}


    /*
     * TODO
     * 
     * mess with sin() to make a good speed
     * 
     * 
     * 
     */


    void FixedUpdate()
    {
        gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x - 0.1f, gameObject.transform.localPosition.y);
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            if (collidedWith == null)
            {
                print("You do lose!");
            }

            else if (collidedWith.name.Contains("Good Zone"))
            {
                print("You do win!");
            }

        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        collidedWith = other.gameObject;
        //print(collidedWith.name);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (collidedWith == other.gameObject)
        {
            collidedWith = null;
        }

    }
}
