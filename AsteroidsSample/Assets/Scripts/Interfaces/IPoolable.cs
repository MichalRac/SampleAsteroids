using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    ObjectPool Pool { get; set; }   
}
