using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHTippy2 : MonoBehaviour
{
    public GameObject Stonehenge;
    public GameObject myFire;
    public GameObject myBeams;
    public bool wasFlipped;
    public bool startingLight;
    float rotAngle;
  
    // Start is called before the first frame update
    void Start()
    {
        wasFlipped = false;
        InvokeRepeating("trackPosition", 1f, 1f);
        startingLight = true;
    }
    void trackPosition()
    {
        //get x y z angles, and make positive
        Vector3 angle = Stonehenge.transform.localEulerAngles;
        float x = Mathf.Abs(angle.x);
        float y = Mathf.Abs(angle.y);
        float z = Mathf.Abs(angle.z);
        //Debug.Log ("____________" + angle + "_______" + Mathf.Round(x) + " , " + Mathf.Round(y) + " , " + Mathf.Round(z) );

        // choose highest value to use below
        if ( (x > z) && (x < 330) && (x > 30) )
        { rotAngle = x;
        }
        else
        { rotAngle = z;
        }

        //if box is upright and has already been triggered, reset trigger ready for next tip
        if ( (rotAngle < 25) || (rotAngle > 335) )
        { if (wasFlipped == true)
            { wasFlipped = false;
            }
        }
        
        //if currently in tipped position and not already set as having been triggered, change to triggered and flip lights
        if ( (rotAngle > 30) && (rotAngle < 330 ) )
        {
            if (wasFlipped == false)
            {
                wasFlipped = true;
                //if light value is set to first setting then change to second setting
                if (startingLight == true)
                {
                    startingLight = false;
                    myFire.SetActive (false);
                    myBeams.SetActive(true);
                }
                else
                {
                    startingLight = true;
                    myFire.SetActive(true);
                    myBeams.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}



