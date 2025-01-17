﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_at_Mouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var addAngle = 270;
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
