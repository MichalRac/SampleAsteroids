using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolableObstacle : IPoolable
{
    int ObstacleID { get; set; }
}
