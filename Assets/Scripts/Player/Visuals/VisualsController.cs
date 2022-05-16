using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualsController : MonoBehaviour
{
    private bool _isFacingRight = true;

    public bool IsFacingRight { get { return  _isFacingRight;  } }


    public void UpdateRotation(float xAxis)
    {
        if (xAxis > 0)
        {
            FaceRight();
            return;
        }

        if (xAxis < 0)
        {
            FaceLeft();
            return;
        }
    }


    public void FaceRight()
    {
        _isFacingRight = true;
        transform.localScale = new Vector2(1, 1);
    }


    public void FaceLeft()
    {
        _isFacingRight = false;
        transform.localScale = new Vector2(-1, 1);
    }
}