using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AutoCarCreate : MonoBehaviour
{
    [NonSerialized]
    public bool IsEnemy = false;
   public GameObject car;
   public float time = 5f;
   public int maxCars = 3;

    // Start is called before the first frame update
    private void Start()
    {
        
        StartCoroutine(SpawnCar());
    }
    IEnumerator SpawnCar(){
        for(int i = 1; i <= maxCars; i++){
            yield return new WaitForSeconds(time);
            Vector3 pos = new Vector3(
                transform.GetChild(0).position.x + UnityEngine.Random.Range(3f, 7f),
                transform.GetChild(0).position.y,
                transform.GetChild(0).position.z + UnityEngine.Random.Range(3f, 7f));
            
            GameObject spawn = Instantiate(car, pos, Quaternion.identity);
            if(IsEnemy)
                spawn.tag = "Enemy";
            
                

        }
    }

}