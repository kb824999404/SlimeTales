using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public Transform resetPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.position = resetPoint.position;
            collision.transform.GetComponent<PlayerAttribute>().Hurt();
        }
    }
}
