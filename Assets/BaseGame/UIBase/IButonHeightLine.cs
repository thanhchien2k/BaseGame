using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButonHeightLine : IClickable
{
    abstract void HightLine();

    float Index { get; set; }
}
