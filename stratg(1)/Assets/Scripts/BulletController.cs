using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BulletController : MonoBehaviour
{
    [NonSerialized]
    public Vector3 position;
    public float speed = 30f;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, position, step);

        if (transform.position == position)
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy") || other.CompareTag("Player")){
            CarAttack attack = other.GetComponent<CarAttack>();
            attack._health -= damage;
            Transform healthBar = other.transform.GetChild(3).transform;
            healthBar.localScale = new Vector3(
               healthBar.localScale.x - 0.6f,
               healthBar.localScale.y,
               healthBar.localScale.z 
            );
            if(attack._health <= 0)
                Destroy(other.gameObject);

        
        } 
    }
}
