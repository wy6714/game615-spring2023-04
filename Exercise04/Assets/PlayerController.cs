using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public GameObject Needle; //slot
    public Rigidbody rb;
    public Transform shootPoint;
    public float TimeLeft;
    public bool TimerOn = false;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    public int score;
    public int IntTimeLeft;


    // Start is called before the first frame update
    void Start()
    {
        score = 1;
        TimerOn = true;
        TimeLeft = 30;
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
            rb.AddForce(needle.transform.forward * 5000);
            //var needleInstance = Instantiate(rb, shootPoint.position, shootPoint.rotation);
            //needleInstance.AddForce(shootPoint.forward * 1000);
            Destroy(needle, 8f);
        }

        if (TimerOn)
        {
            if (TimeLeft > 0 && score < 7)
            {
                TimeLeft -= Time.deltaTime;
                IntTimeLeft = (int)Mathf.Round(TimeLeft);
                TimerText.text = IntTimeLeft.ToString();
            }
            else if (TimeLeft > 0 && score == 7)
            {
                ScoreText.text = "You Win!";
            }
            else
            {
                TimeLeft = 0;
                TimerText.text = TimeLeft.ToString();
                IntTimeLeft = (int)Mathf.Round(TimeLeft);
                TimerOn = false;
                ScoreText.text = "You lose!";

            }
        }




    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            ScoreText.text = score.ToString();
            score++;


        }


    }




}
