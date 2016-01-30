using UnityEngine;
using System.Collections;

public class GaugeManager : MonoBehaviour {

    public static int numbGood = 2;


    bool[] goodZoneBool = new bool[numbGood];


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetGoodZoneSucess(int index, bool val)
    {
        goodZoneBool[index] = val;
    }
    public bool[] GetZoneBool()
    {
        return goodZoneBool;
    }

}
