using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBorder : MonoBehaviour {

    public float padding = 10f; //padding from bounds to destroy object
    public Color debugColor = Color.red;

    public void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(padding);
        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }

    private void Update()
    {
        //get camera bounds with padding
        Bounds camBounds = Camera.main.GetBounds(padding);
        //if position is out of bounds
        if (!camBounds.Contains(transform.position))
        {
            //destroy it
            Destroy(gameObject);
        }
    }

}
