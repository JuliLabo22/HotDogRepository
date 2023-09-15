using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggeable 
{
    void OnDrag(Vector3 offset);
    void OnDrop();
    void OnFollow(Vector3 pos);
}
