using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : MonoBehaviour
{
    bool isDestroy = false;
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
        if(collision.gameObject.tag == "Player")
        {
            CharacterChange changeScript = 
                collision.transform.gameObject.GetComponent<CharacterChange>();
            if(changeScript.getCurrentCharacter()==1)
            {
                destroy();
            }
        }
    }
    void destroy()
    {
        if(isDestroy)   return;
        foreach(Transform child in transform)
        {
            Rigidbody rigidbody = child.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
        }
        isDestroy = true;
    }
}
