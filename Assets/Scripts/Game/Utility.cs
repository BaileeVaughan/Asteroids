using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{

    //calculates and returns a random position on a bounds
    public static Vector3 GetRandomPosOnBounds(this Bounds bounds)
    {
        Vector3 result = Vector3.zero; //result to return at end of this function
        //smaller variable name for bounds min and max
        Vector3 min = bounds.min;
        Vector3 max = bounds.max;
        bool topOrBottom = Random.Range(0, 2) > 0; //50% chance its top or bpttom or left or right
        bool top = Random.Range(0, 2) > 0; //50% chance its top or bottom
        bool right = Random.Range(0, 2) > 0; //50% chance its left or right
        //top or bottom?
        if (topOrBottom)
        {
            //get random range on x
            result.x = Random.Range(min.x, max.x);
            //top or bottom
            result.y = top ? max.y : min.y;
        }
        //left or right?
        else
        {
            //left or right?
            result.x = right ? max.x : min.x;
            //get random range on y
            result.y = Random.Range(min.y, max.y);
        }
        return result;
    }

    //calculates and returns camera bounds with given padding (default to 1f)
    public static Bounds GetBounds(this Camera cam, float padding = 1f)
    {
        //define camera dimensions float 
        float camHeight, camWidth;
        //get position of camera
        Vector3 camPos = cam.transform.position;
        //calculate height and width of camera
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        //apply padding
        camHeight += padding;
        camWidth += padding;
        //create a camera bounds from above information
        return new Bounds(camPos, new Vector3(camWidth, camHeight, 100));
    }
}
