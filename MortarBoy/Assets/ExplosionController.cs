using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    GameObject Player;
    GameObject[] EGuns;
    GameObject[] AGuns;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EGuns = GameObject.FindGameObjectsWithTag("ECannon");
        AGuns = GameObject.FindGameObjectsWithTag("ACannon");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
