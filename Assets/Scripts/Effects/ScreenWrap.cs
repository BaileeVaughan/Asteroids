using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{

    public float padding = 3f; //padding around the screen for screen wrapping
    public Color debugColor = Color.blue; //color of gizmos

    private SpriteRenderer spriteRenderer; //reference to sprite renderer

    void Awake()
    {
        //Get reference to sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnDrawGizmos()
    {
        //Get the bounds around the camera with given padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //then draw the camera bounds 
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    //updates position of entity
    void UpdatePosition()
    {
        //get the camera dimensions using padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //store position and size in a shorter variable name
        Vector3 pos = transform.position;
        //store min and max vectors
        Vector3 min = camBounds.min;
        Vector3 max = camBounds.max;
        //check left
        if (pos.x < min.x)
        {
            pos.x = max.x;
        }
        //check right
        if (pos.x > max.x)
        {
            pos.x = min.x;
        }
        //check up
        if (pos.y < min.y)
        {
            pos.y = max.y;
        }
        //check down
        if (pos.y > max.y)
        {
            pos.y = min.y;
        }
        //Apply position
        transform.position = pos;
    }

    void LateUpdate()
    {
        //update the players position
        UpdatePosition();
    }
}
