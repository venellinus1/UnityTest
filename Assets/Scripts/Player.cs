using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      count =0;
      setCountText();
      
    }


    void FixedUpdate()
    {
      float moveHorizontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      Vector3 movement=new Vector3(moveHorizontal,0,moveVertical);
      rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)  {
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count++;
            setCountText();
            if (count >= 10) setWinText();
        }
    }

    void setCountText(){
      countText.text = "Count: "+count.ToString();
    }
    void setWinText(){
      winText.text = "You Won !";
    }
}
