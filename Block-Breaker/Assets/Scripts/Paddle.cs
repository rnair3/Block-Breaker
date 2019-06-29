using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config parameters
    [SerializeField] float minX = 1;
    [SerializeField] float maxX = 15;

    [SerializeField] int screenWidthInUnits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits);
        float x = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(x, minX, maxX);
        transform.position = paddlePosition;

    }
}
