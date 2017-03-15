using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyTest : MonoBehaviour {
    public SimpleStrategy strategy;
    public void Update()
    {
        strategy.Move(this.transform);
    }
}
