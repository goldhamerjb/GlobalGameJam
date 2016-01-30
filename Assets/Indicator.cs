using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {
    GameObject collidedWith = null;
    public GameObject staticIndicator;
    //public string str;
    float foo = 0;

    float amplitude=0;
    float frequency=0;

    bool move = false;

    int directionScalar = 1; //equals 1 when to the right, -1 when to the left


	// Use this for initialization
	void Start () {
        StartCoroutine("StartMove");
	
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
       //  foo += 0.0001f;
        if (move)
        {
            gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x + 0.3f * directionScalar, gameObject.transform.localPosition.y); 
        }
        //linear
        //gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x - Mathf.Sin(foo*9) - 1, gameObject.transform.localPosition.y);
        //print(Vector3.Distance(a,b);


         //gameObject.transform.position +=  (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - Time.deltaTime))) * transform.up;
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
                GameObject spawn;

                spawn = Instantiate(staticIndicator);

                spawn.transform.position = gameObject.transform.position;
                
                //print("You do win!");
            }

        }

        

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        
        collidedWith = other.gameObject;
        //print(collidedWith.name);

        if (collidedWith.name.Contains("Side Trigger"))
        {
            directionScalar = directionScalar * (-1);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (collidedWith == other.gameObject)
        {
            collidedWith = null;
        }

    }

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1f);

        move = true;
    }
}
