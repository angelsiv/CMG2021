using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfMolecule : MonoBehaviour
{
    enum Direction { LEFT, RIGHT, UP, DOWN };
    public GameObject mol;
    public float force = 3;

    Direction diRight = Direction.RIGHT;
    Direction dirUp =Direction.UP;
    Rigidbody rigidbody;


    void Awake() {
       rigidbody = GetComponent<Rigidbody>();
   }
    void OnCollisionEnter(Collision c){
         if (c.gameObject.tag == "MoleculeTest"){
            Vector3 dir = c.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rigidbody.AddForce(dir*force);
         }
    }
    void Update()
    {
        if(transform.position.x <= -1170f) rigidbody.AddForce(new Vector3(1,0,0) * 5, ForceMode.VelocityChange);
        if(transform.position.x >= 1170f) rigidbody.AddForce(new Vector3(-1,0,0)* 5, ForceMode.VelocityChange);
        if(transform.position.y <= -1170f) rigidbody.AddForce(new Vector3(0,1,0)* 5, ForceMode.VelocityChange);
        if(transform.position.y >= 1170f) rigidbody.AddForce(new Vector3(0,-1,0)* 5, ForceMode.VelocityChange);
    }

}
