﻿using UnityEngine;using System.Collections;public class GoodZones : MonoBehaviour {    bool getgot = false;
    public int index;
    GaugeManager gm;	// Use this for initialization	void Start () {
        GameObject.Find("Bad Zone").GetComponent<GaugeManager>();	}		// Update is called once per frame	void Update () {	    	}    public void SetGot(bool o)    {        getgot = o;
        GameObject.Find("Bad Zone").GetComponent<GaugeManager>().SetGoodZoneSucess(index, true);
    }    public bool GetGot()    {        return getgot;    }}