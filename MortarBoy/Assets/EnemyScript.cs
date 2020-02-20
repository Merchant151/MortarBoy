using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    CannonController cannon;
    public GameObject mortarBoy;
    float power;
    bool activeClock;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        activeClock = false;
        //wait = Random.Range(3, 9);
        cannon = GetComponent<CannonController>();
        mortarBoy = GameObject.FindGameObjectWithTag("Player");
        //Invoke("shootMortarBoy", wait);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeClock)
        {
            timer += Time.deltaTime;
            if(timer > 8)
            {
                activeClock = false;
            }
        }
        shootMortarBoy();
    }

    void shootMortarBoy()
    {

        gameObject.transform.LookAt(mortarBoy.transform.position);
        gameObject.transform.Rotate(cannon.transform.right, -50, Space.World); 
        float power;
        power = Random.Range(30, 100);
        if (!activeClock)
        {
            StartClock();
            cannon.shoot(power);
        }
    }

    void StartClock()
    {
        activeClock = true;
        timer = 0;
    }

}
