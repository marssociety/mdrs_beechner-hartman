using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class Player_Interaction : MonoBehaviour
{

    public Text countText;
    public Text soilText;
    public Text winText;
    public GameObject Car;

    private GameObject FakeCar;
    private Transform Player;
    private Transform InCarPosition;
    private int objectiveCount;
    private int soilCount;

    void Start()
    {
        //fix car audio or delete it
        objectiveCount = 0; //preset marker count
        soilCount = 0;      //preset soil count
        SetCountText();     //display each initial.
        SetSoilText();
        winText.text = "";
        //start: get player's transform
        Player = GameObject.FindWithTag("Player").transform;
        //start: attach code to objects
        Car = GameObject.FindWithTag("Car");
        FakeCar = GameObject.FindWithTag("FakeCar");

        // Preset Car
        Car.gameObject.SetActive(false); //make sure car is "true" at start
        FakeCar.gameObject.SetActive(true);
        // Preset Person
        Player.gameObject.SetActive(true);
        Player.GetComponent<Camera>().enabled = true;

    }
    //Collision:
    // if tag of collision object="Pickup", raise count and 'save' change via SetCountText()
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            objectiveCount++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Soil"))
        {
            other.gameObject.SetActive(false);
            soilCount++;
            SetSoilText();

        }
        /*
         else if (other.gameObject.CompareTag("Talk"))
        {
            //set animator trigger
            // AnimateWalk.Play;
        }
        */
        else if (other.gameObject.CompareTag("FakeCar"))
        {
            other.gameObject.SetActive(false);
            //EnterCar();
        }



    }


    // Displays the current "count" #
    void SetCountText()
    {
        countText.text = "Markers Collected: " + objectiveCount.ToString() + "/6";
        if (objectiveCount >= 6)
        {
            winText.text = "Mission Complete!";
        }
    }

    //Displays the current "soil" #
    void SetSoilText()
    {
        soilText.text = "Samples Collected: " + soilCount.ToString() + "/3";
        if (soilCount >= 3)
        {
            winText.text = "Return to the Hab.";
        }
    }

    void EnterCar()
    {

        Car.gameObject.SetActive(true);
        FakeCar.gameObject.SetActive(false);

        Player.gameObject.SetActive(false);
        Player.GetComponent<Camera>().enabled = false;

    }

    void ExitCar()
    {

        Car.gameObject.SetActive(false);
        FakeCar.gameObject.SetActive(true);

        Player.gameObject.SetActive(true);
        Player.GetComponent<Camera>().enabled = true;
        //           Player.transform.position.y= Car.transform.position;
    }

    void Update()
    {
        var distance = Car.transform.position - Player.position;
        if (Input.GetKeyDown("e"))
        {
            // first check in-car
            if ((distance.sqrMagnitude <= 4 * 4) && (Car.gameObject.activeInHierarchy == false))
            {
                EnterCar();
            }


            // else exit person
            else if (Car.gameObject.activeInHierarchy == true)
            {
                ExitCar();
            }

        }
    }
}