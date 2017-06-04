using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FoodSpawner : MonoBehaviour {

    public List<Food> ListOfSpawnableFood;
    public bool CurrentlyHasFood;
    private Food foodToSpawn;
    public ChewTimeTimer ChewBarController;

    public List<GameObject> ListOfSpawnedFood;

    public bool HasEnabledOrDisabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!CurrentlyHasFood)
        {            
            if(ListOfSpawnableFood.Count > 0)
            {
                if(ChewBarController.CurrentChewTime == 0) { 
                    foodToSpawn = Instantiate(ListOfSpawnableFood[UnityEngine.Random.Range(0, ListOfSpawnableFood.Count)], gameObject.transform.position, new Quaternion(), gameObject.transform);
                    CurrentlyHasFood = true;
                    ChewBarController.ListOfSpawnedFood.Add(foodToSpawn.gameObject);              
                }
            }            
        }        
	}
}
