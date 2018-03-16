using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AirSupply : MonoBehaviour {

    public Text airText;
    public  float airtime = 20;
    public Text winText;
    public Rigidbody playerrb;

    // Use this for initialization
    void Start ()
    {
        playerrb = GetComponent<Rigidbody>();
        winText.text = "";
        SetAirText();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {    //trying to set up air display
        if (airtime >= 0)
        {
            airtime =airtime-Time.fixedDeltaTime;
        }
        else
        {
            airtime = -1;
        }
    }

    void Update()
    {

        SetAirText();
    }
    // updates the oxygen left
    void SetAirText()
    {
        airText.text = "Air: " + Mathf.Ceil(airtime).ToString();
        if (airtime < 0)
        {
            winText.text = "You are dead.";
            playerrb.isKinematic = false;

        }
    }
}
