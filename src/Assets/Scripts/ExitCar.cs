using UnityEngine;
using System.Collections;

public class ExitCar : MonoBehaviour
{

    public GameObject Car;
    private GameObject FakeCar;
    private Transform Player;
    private Transform InCarPosition;
   // private Rotator CarOrientation;
    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindWithTag("Player").transform;
        InCarPosition = GameObject.FindWithTag("Car").transform;
        //CarOrientation = GameObject.FindWithTag("Car").transform.rotation;
        //start: attach code to objects
        Car = GameObject.FindWithTag("Car");
        FakeCar = GameObject.FindWithTag("FakeCar");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("e"))
        {
            FakeCar.gameObject.transform.localPosition=new Vector3(InCarPosition.localPosition.x, InCarPosition.localPosition.y,InCarPosition.localPosition.z);
            Player.localPosition = new Vector3(InCarPosition.localPosition.x+1, InCarPosition.localPosition.y+1, InCarPosition.localPosition.z+1);
           // FakeCar.gameObject.transform.rotation = new Vector3(CarOrientation.x,CarOrientation.y,CarOrientation.z);
            Car.gameObject.SetActive(false);
            FakeCar.gameObject.SetActive(true);

            Player.gameObject.SetActive(true);
            Player.GetComponent<Camera>().enabled = true;
        }
	
	}
}
