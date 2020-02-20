using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    //public int pleaseShowUp;
    public GameObject exploPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -100)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "ACannon"||collision.gameObject.tag=="ECannon"){
            Destroy(collision.gameObject);
        }

        Instantiate(exploPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    
    }

}
