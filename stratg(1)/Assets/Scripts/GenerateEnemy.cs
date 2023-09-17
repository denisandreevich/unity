using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public Transform[] points;
    public GameObject factory;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFactory());        
    }
    IEnumerator SpawnFactory()
    {
        for(int i = 0; i < points.Length; i++){
            yield return new WaitForSeconds(10f);
            GameObject spawn = Instantiate(factory);
            Destroy(spawn.GetComponent<PlaceObjects>());
            spawn.transform.position = points[i].position;
            spawn.transform.rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 360),0));
            spawn.GetComponent<AutoCarCreate>().enabled = true;
            spawn.GetComponent<AutoCarCreate>().IsEnemy = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
