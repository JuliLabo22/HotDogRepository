using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggeable 
{
    void OnStartDrag(Vector3 offset);
    void OnDrop();
    void OnDrag(Vector3 pos);
}
