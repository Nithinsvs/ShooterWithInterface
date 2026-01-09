using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriplePress : MonoBehaviour
{
    private float _offsetTime = 0.2f;
    private int _buttonPressCount = 1;
    private float _lastPressedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button pressed");

            if (Time.time - _lastPressedTime < _offsetTime)
            {
                _buttonPressCount += 1;
            }
            else
            {
                _buttonPressCount = 1;
            }
            _lastPressedTime = Time.time;

            if(_buttonPressCount == 3)
            {
                Debug.Log("Triple button detected");
            }
        }
    }
}
