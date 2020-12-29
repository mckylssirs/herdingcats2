using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HerdManager : MonoBehaviour
{

    public GameObject cat;
    public int nCats = 10;
    public float speed = 5.0f;
    private List<GameObject> oldHerd = new List<GameObject>();
   
    // Start is called before the first frame update
    void Start()
    {
        float rotateX,rotateY;
        for (int i = 0; i < nCats; i++) {
            rotateX = Random.Range(-1.0f, 1.0f);
            rotateY = Random.Range(-1.0f, 1.0f);
            GameObject newCat = Instantiate(cat, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0),
                Quaternion.identity);
     //       newCat.transform.rotation = new Vector3(rotateX, rotateY, 0);
            Rigidbody2D rb = newCat.GetComponent<Rigidbody2D>();
            
            oldHerd.Add(newCat);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
