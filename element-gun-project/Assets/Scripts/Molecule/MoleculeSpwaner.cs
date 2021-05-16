using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeSpwaner : MonoBehaviour
{
    public GameObject mol;
    public int numberMol;
    // Start is called before the first frame update

    //public GameObject terrain;
    //private MeshCollider collider;
    void Start()
    {
        //collider = terrain.GetComponent<MeshCollider>();
        GenetrateObject(mol,numberMol);
    }
    void GenetrateObject(GameObject molObject, int amout){
        if( molObject == null) return;

        for(int i=0; i < amout; i++){
            Vector3 randompoints = GetRandomPoints();
            GameObject clone = Instantiate(molObject, new Vector3( randompoints.x,randompoints.y,0f), UnityEngine.Quaternion.identity);
            Vector3 vec = (clone.transform.position - GetRandomPoints()).normalized; 
            clone.GetComponent<Rigidbody>().AddForce(vec * 500,ForceMode.VelocityChange);
            
        }
    }

    Vector3 GetRandomPoints(){
        int xRandom = 0; 
        int yRandom = 0;

        xRandom = (int) Random.Range(0f,1000f);
        yRandom = (int) Random.Range(0f,1000f);

        return new Vector3(xRandom,yRandom,0.0f);
    }
}
