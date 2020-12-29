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
        float rotateX, rotateY;
        for (int i = 0; i < nCats; i++) {
            rotateX = Random.Range(0, 360f);
            rotateY = Random.Range(-1.0f, 1.0f);
            GameObject newCat = Instantiate(cat, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0),
                Quaternion.identity);
    //        newCat.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotateX));
            //       newCat.transform.rotation = new Vector3(rotateX, rotateY, 0);
            Rigidbody2D rb = newCat.GetComponent<Rigidbody2D>();
            rotateX = rotateX * 3.1415962535f / 180.0f;
            
            rb.velocity = new Vector2(Mathf.Cos(rotateX * speed), Mathf.Sin(rotateX * speed));
            newCat.transform.eulerAngles = Vector3.forward * rotateX;
//            newCat.transform.right = rb.velocity.normalized;
            oldHerd.Add(newCat);
        }
    }

    // Update is called once per frame
    void Update() {
        Vector2 pos;
        foreach (GameObject cat in oldHerd)
        {
            Rigidbody2D rb = cat.GetComponent<Rigidbody2D>();
            pos = rb.position;
            if (pos.x>10 || pos.x<-10) {
               rb.velocity=new Vector2(-rb.velocity.x, rb.velocity.y);
                rb.position = pos + rb.velocity;
            }
            if (pos.y > 5 || pos.y < -5)
            {
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
                rb.position = pos + rb.velocity;
            }
            cat.transform.right = rb.velocity.normalized;
        }

    }
}
