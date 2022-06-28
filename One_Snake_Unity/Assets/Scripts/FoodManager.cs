using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodManager : MonoBehaviour
{

    public GameObject food;
    public Transform floorTransform;        // for positioning the food on floor

    private float posX, posY, posZ;
    private float minX, maxX, minY, maxY;   // range in which the food is spawned
    


    // Use this for initialization
    void Start()
    {
        

        Invoke("AddFood", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // add food to the screen
    void AddFood()
    {
        posX = Random.Range(-9.5f, 9.5f);
        posY = 0.5f;
        posZ = Random.Range(-9.5f, 9.5f);
        Instantiate(food, new Vector3(posX, posY, posZ), Quaternion.identity);

        Invoke("AddFood", 2f);
    }

    // set food spawn range based on floor
    void setFoodSpawnRange()
    {
        minX = floorTransform.sc;
    }

}
