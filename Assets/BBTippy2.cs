using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBTippy2 : MonoBehaviour
{
    public GameObject Brandenburg;
    public GameObject eastLight;
    public GameObject westLight;
    public bool BBwasFlipped;
    public bool BBstartingLight;
    float BBrotAngle;

    // Start is called before the first frame update
    void Start()
    {
        BBwasFlipped = false;
        InvokeRepeating("trackPosition", 1f, 1f);
        BBstartingLight = true;
    }
    void trackPosition()
    {
        //get x y z angles, and make positive
        Vector3 angle = Brandenburg.transform.localEulerAngles;
        float x = Mathf.Abs(angle.x);
        float y = Mathf.Abs(angle.y);
        float z = Mathf.Abs(angle.z);
        //Debug.Log ("____________" + angle + "_______" + Mathf.Round(x) + " , " + Mathf.Round(y) + " , " + Mathf.Round(z) );

        // choose highest value to use below
        if ((x > z) && (x < 330) && (x > 30))
        {
            BBrotAngle = x;
        }
        else
        {
            BBrotAngle = z;
        }

        //if box is upright and has already been triggered, reset trigger ready for next tip
        if ((BBrotAngle < 25) || (BBrotAngle > 335))
        {
            if (BBwasFlipped == true)
            {
                BBwasFlipped = false;
            }
        }

        //if currently in tipped position and not already set as having been triggered, change to triggered and flip lights
        if ((BBrotAngle > 30) && (BBrotAngle < 330))
        {
            if (BBwasFlipped == false)
            {
                BBwasFlipped = true;
                //if light value is set to first setting then change to second setting
                if (BBstartingLight == true)
                {
                    BBstartingLight = false;
                    eastLight.SetActive(false);
                    westLight.SetActive(true);
                }
                else
                {
                    BBstartingLight = true;
                    eastLight.SetActive(true);
                    westLight.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}



