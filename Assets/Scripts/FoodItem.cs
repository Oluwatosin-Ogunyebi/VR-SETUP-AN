using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{   
    //Spawn some food before you destroy
    //Destroy FoodItem after a couple of seconds

    public void DestroyAfterDelay(int time)
    {
        Invoke("SpawnFood", time);
        Destroy(this.gameObject, time);
    }

    void SpawnFood()
    {
        GameManager.Instance.SpawnFoodItem();
    }
}
