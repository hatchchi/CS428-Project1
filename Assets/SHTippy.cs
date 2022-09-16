using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHTippy : MonoBehaviour
{

    
    public GameObject Stonehenge;

    public bool hasBeenFlipped;

    // Start is called before the first frame update
    void Start()
    {
        hasBeenFlipped = false;
        InvokeRepeating("keepTrackOfPosition", 1f, 1f);
    }

    void keepTrackOfPosition()
    {
        //var xPos = UnityEditor.TransformUtils.GetInspectorRotation(Stonehenge.transform).x;
        var xPos = getEditorNumbers();
        Debug.Log(":\nReceived cube 1 x: " + xPos);

        // if its held between 30 degrees either way

        if ( (xPos < 30 && xPos > 0) || (xPos > -30 && xPos < 0 ) ) 
        {
            //not tipped
            if(hasBeenFlipped == true)
            {
                //____________________add light action in here
                
                hasBeenFlipped = false;
                Debug.Log(":\nQuote Position: " + xPos);
            }
        }

        // if its upside down (to stop issues with rotating all the way around)
        if ((xPos < 180 && xPos > 150) || (xPos > -180 && xPos < -150))
        {
            hasBeenFlipped = true;        
        }

    }

    float getEditorNumbers()
    {
        Vector3 angle = Stonehenge.transform.eulerAngles;
        float x = angle.x;
        float y = angle.y;
        float z = angle.z;

        //adjust x value if wrong way round

        if (Vector3.Dot(transform.up, Vector3.up) >= 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = angle.x - 360f;
            }
        }

        //adjust y and z values if wrong way round

        if (angle.y > 180)
        {
            y = angle.y - 360f;
        }

        if (angle.z > 180)
        {
            z = angle.z - 360f;
        }

        Debug.Log(angle + "_____" + Mathf.Round(x) + " , " + Mathf.Round(y) + " , " + Mathf.Round(z));
        return x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
