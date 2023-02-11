using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IReward
    {
        string Id { get; }
        string Type { get; }
        int Amount { get; }
    }
}