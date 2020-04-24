using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pickup : MonoBehaviour
{

    private static int count;
    private static int score;
    public Text CountText;
    public Text WinText;
    public Text Score;

    void Start()
    {
        score = 0;
        count = 0;
        setCountText();
        WinText.text = "";
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            setCountText();
        }
        if (other.gameObject.CompareTag("whiteball"))
        {
            //other.gameObject.SetActive(false);
            //playerObject = other.gameObject;
            other.gameObject.transform.position = new Vector3((float)0, (float)0.5, (float)0);
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;//移動速度 =0
            rb.angularVelocity = Vector3.zero;
            score = score - 1;
            setCountText();

        }
    }
    void setCountText()
    {
        CountText.text = "Count:" + count.ToString();
        Score.text = "Score:" + score.ToString();
        if (count >= 9)
        {
            WinText.text = "You Win!";
        }
        

    }
}
