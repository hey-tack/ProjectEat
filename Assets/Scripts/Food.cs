using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour {

    public string Name;
    public float ChewTime;

    public RectTransform ChewBarTimer;
    public ChewTimeTimer ChewBarController;
    private bool HasBeenClicked = false;


    void Start () {
		
	}

    void Awake()
    {
        ChewBarTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<RectTransform>();
        ChewBarController = GameObject.Find("ChewBarController").GetComponent<ChewTimeTimer>();
    }

    	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        
        if(!HasBeenClicked)
        { 
            
            ChewBarController.CurrentChewTime = ChewTime;
            ChewBarController.Chew();        
            gameObject.GetComponentInParent<FoodSpawner>().CurrentlyHasFood = false;
            ChewBarController.ListOfSpawnedFood.Remove(gameObject);
            HasBeenClicked = true;
            Destroy(gameObject);
        }

        
    }
}
