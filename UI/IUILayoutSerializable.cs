using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IUILayoutSerializable
{
    string GetPrefabKey();
    string GetDetailLeftPrefabKey();
    string GetDetailRightPrefabKey();
    string GetName();
    Rect GetLayoutRect();
}
