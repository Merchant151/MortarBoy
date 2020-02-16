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
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(exploPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    
    }

}
