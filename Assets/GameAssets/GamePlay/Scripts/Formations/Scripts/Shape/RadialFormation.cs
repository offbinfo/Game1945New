using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadialFormation : FormationBase {
    [Header("Radial Formation")]
    [SerializeField] private float _radius = 1;
    [SerializeField] private float _radiusGrowthMultiplier = 0;
    [SerializeField] private float _rotations = 1;
    [SerializeField] private int _rings = 1;
    [SerializeField] private float _ringOffset = 1;
    [SerializeField] private float _nthOffset = 0;

    public override List<Vector3> GetPositions()
    {
        if (_posCount <= 1)
        {
            return new List<Vector3>() { Vector3.zero };
        }
        List<Vector3> posL = new List<Vector3>();
        var amountPerRing = _posCount / _rings;
        var ringOffset = 0f;
        for (var i = 0; i < _rings; i++)
        {
            for (var j = 0; j < amountPerRing; j++)
            {
                var angle = j * (Mathf.PI * 2) * _rotations / amountPerRing + (i % 2 != 0 ? _nthOffset : 0);

                var radius = _radius + ringOffset + j * _radiusGrowthMultiplier;
                var x = Mathf.Cos(angle) * radius;
                var y = Mathf.Sin(angle) * radius;

                var pos = new Vector3(x, y, 0) ;

                //pos += GetNoise(pos);

                pos *= _spread;

                posL.Add(pos + transform.position);
            }

            ringOffset += _ringOffset;
        }
        return posL;
    }

    /*public override IEnumerable<Vector3> EvaluatePoints() {
        var amountPerRing = _amount / _rings;
        var ringOffset = 0f;
        for (var i = 0; i < _rings; i++) {
            for (var j = 0; j < amountPerRing; j++) {
                var angle = j * Mathf.PI * (2 * _rotations) / amountPerRing + (i % 2 != 0 ? _nthOffset : 0);

                var radius = _radius + ringOffset + j * _radiusGrowthMultiplier;
                var x = Mathf.Cos(angle) * radius;
                var z = Mathf.Sin(angle) * radius;

                var pos = new Vector3(x, 0, z);

                pos += GetNoise(pos);

                pos *= Spread;

                yield return pos;
            }

            ringOffset += _ringOffset;
        }
    }*/
}