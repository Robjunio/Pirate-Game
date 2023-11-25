using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorderHandler : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D col)
    {
        var point = col.transform.position;

        col.gameObject.transform.position = new Vector2(-point.x, -point.y);
    }
}
