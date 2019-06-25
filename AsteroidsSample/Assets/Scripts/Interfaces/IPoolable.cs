using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    BasePool Pool { get; set; }   
}
