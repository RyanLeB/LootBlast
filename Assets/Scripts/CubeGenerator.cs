using UnityEngine;

public class CubeGenerator : MonoBehaviour
{

    public GameObject preFab;

    // Start is called before the first frame update
    void Start()
    {
        // INSTANCE
        //-----------------
        // gameObject.transform.Translate(Vector3.zero);




        // CLASS 
        //-----------------
        GameObject newObject;
        // cube
        newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // preFab
        // newObject = GameObject.Instantiate(preFab); // This is what's used in practice

        // change color
        newObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

        newObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //GameObject newObject;
        // cube
        //newObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        // preFab
        // newObject = GameObject.Instantiate(preFab); // This is what's used in practice

        // change color
        //newObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

        //newObject.AddComponent<Rigidbody>();

        //GameObject newObject2;
        //newObject2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //newObject.AddComponent<Rigidbody>();
        //newObject2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }
}