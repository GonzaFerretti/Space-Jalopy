using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgHandler : MonoBehaviour
{
    public GameObject bg1;
    public GameObject bg2;
    public GameObject currentBg;
    public float bgHeight;
    public float speed;

    private void Start()
    {
        currentBg = bg1;
        Debug.Log(bg1.GetComponent<SpriteRenderer>().bounds.size);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentBg.transform.position.y < -bgHeight)
        {
            Debug.Log("hola");
            if (currentBg == bg1)
            {
                bg1.transform.position = Vector2.up * bgHeight;
                currentBg = bg2;
                bg2.transform.position = Vector3.zero;
            }
            else
            {
                bg2.transform.position = Vector2.up * bgHeight;
                currentBg = bg1;
                bg1.transform.position = Vector3.zero;
            }
        }
        else
        { 
        Vector2 movement = Vector2.up * Time.deltaTime * speed;
        bg1.transform.position += new Vector3(movement.x,movement.y, 0);
        bg2.transform.position += new Vector3(movement.x, movement.y, 0);
        }
    }
}
