using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 75f;
    public GameObject Needle; //slot
    public Rigidbody rb;
    public Transform shootPoint;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        gameObject.transform.Translate(gameObject.transform.forward * Time.deltaTime * moveSpeed * vAxis, Space.World);

        gameObject.transform.Rotate(0, rotateSpeed * Time.deltaTime * hAxis, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject needle = Instantiate(Needle, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = needle.GetComponent<Rigidbody>();
            rb.AddForce(needle.transform.forward * 1000);
            //var needleInstance = Instantiate(rb, shootPoint.position, shootPoint.rotation);
            //needleInstance.AddForce(shootPoint.forward * 1000);
            Destroy(needle, 3f);
        }
      

    }

    
}
