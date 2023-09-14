using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggeable 
{
    void OnDrag();
    void OnDrop();
    void OnFollow(Vector3 pos);
}
