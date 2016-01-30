using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {
    GameObject collidedWith = null;
    public GameObject staticIndicator;

    float badZoneLength;

    bool move = false;
    bool stop = false;

    int directionScalar = 1; //equals 1 when to the right, -1 when to the left

    public float frequency = 2.0f;  // Speed of sine movement
    private Vector3 axis;
    private Vector3 pos;


	// Use this for initialization
	void Start () {
        // badZoneLength = 2 * GameObject.Find("Bad Zone").transform.position.x - gameObject.transform.position.x;
        badZoneLength = GameObject.Find("Bad Zone").transform.localScale.x;


        StartCoroutine("StartMove");

        
        pos = transform.position;

	}


    void FixedUpdate()
    {
        if (move && !stop)
        {

            transform.position = pos + transform.right * (Mathf.Cos(Time.time * frequency) * badZoneLength * 3.1415f);

            //gameObject.transform.localPosition = new Vector2(gameObject.transform.localPosition.x + 0.1f * directionScalar, gameObject.transform.localPosition.y); 
        }
        

    
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            if (collidedWith == null)
            {
                stop = true;
                print("You do lose!");
                directionScalar = 0;
            }

            else if (collidedWith.name.Contains("Good Zone") && !collidedWith.GetComponent<GoodZones>().GetGot())
            {
                GameObject spawn;

                spawn = Instantiate(staticIndicator);
                spawn.transform.position = gameObject.transform.position;
                
                print("You do win!");
                collidedWith.GetComponent<GoodZones>().SetGot(true);

                //check if all green has been got
                bool sucess = true;
                bool[] foo = GameObject.Find("Bad Zone").GetComponent<GaugeManager>().GetZoneBool();

                foreach(bool i in foo) {
                    if (!i) {
                        sucess = false;
                    }
                }

                if (sucess) {
                    stop = true;
                    directionScalar = 0;
                }

                //print(" [0] = " + GameObject.Find("Bad Zone").GetComponent<GaugeManager>().GetZoneBool()[0]);
                //print(" [1] = " + GameObject.Find("Bad Zone").GetComponent<GaugeManager>().GetZoneBool()[1]);


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
        collidedWith = null;

    }

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1f);

        move = true;
    }
}
