using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonBallP;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        //shoot(30f);
    }

    public Rigidbody shoot(float power)
    {
        GameObject g = Instantiate(cannonBallP, spawnPoint.transform.position, transform.rotation) as GameObject;
        Rigidbody body = g.GetComponent<Rigidbody>();
        body.AddForce(transform.forward.normalized * power, ForceMode.Impulse);
        return g.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
