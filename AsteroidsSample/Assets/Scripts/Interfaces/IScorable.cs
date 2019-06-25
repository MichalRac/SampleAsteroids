using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScorable
{
    int ScoreValue { get; set; }
    void Score(int value);
}
