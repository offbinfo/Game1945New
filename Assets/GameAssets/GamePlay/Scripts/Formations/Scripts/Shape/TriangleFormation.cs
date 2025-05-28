using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriangleFormation : FormationBase {
    [Header("Triangle Formation")]
    [SerializeField] private bool _centerUnits = true;
    [SerializeField] private bool _pivotInMiddle = true;
    [SerializeField] private float _nthOffset = 0;

    /*public override IEnumerable<Vector3> EvaluatePoints() {
        var middleOffset = new Vector3(_unitWidth * 0.5f, _unitDepth * 0.5f, 0);

        for (var x = 0; x < _unitWidth; x++) {
            for (var y = 0; y < _unitDepth; y++) {
                if (_hollow && x != 0 && x != _unitWidth - 1 && y != 0 && y != _unitDepth - 1) continue;
                var pos = new Vector3(x + (y % 2 == 0 ? 0 : _nthOffset), y, 0);

                pos -= middleOffset;

                pos += GetNoise(pos);

                pos *= Spread;

                yield return pos;
            }
        }
    }*/

    public override List<Vector3> GetPositions()
    {
        List<Vector3> unitPositions = new List<Vector3>();

        // Offset starts at 0, then each row is applied change for half of _spread
        float currentRowOffset = 0f;
        float x, y;
        int row;
        int rowCount = (int)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * _posCount)) / 2);
        for (row = 0; unitPositions.Count < _posCount; row++)
        {
            // Current unit positions are the index of first unit in row
            var columnsInRow = row + 1;
            var firstIndexInRow = unitPositions.Count;

            for (int column = 0; column < columnsInRow; column++)
            {
                x = column * _spread + currentRowOffset;
                y = row * _spread;

                // Check if centering is enabled and if row has less than maximum
                // allowed units within the row.
                if (_centerUnits &&
                    row != 0 &&
                    firstIndexInRow + columnsInRow > _posCount)
                {
                    // Alter the offset to center the units that do not fill the row
                    var emptySlots = firstIndexInRow + columnsInRow - _posCount;
                    x += emptySlots / 2f * _spread;
                }

                unitPositions.Add(new Vector3(x + (row % 2 == 0 ? 0 : _nthOffset), -y, 0) + transform.position);

                if (unitPositions.Count >= _posCount) break;
            }

            currentRowOffset -= _spread / 2;
        }


        if (_pivotInMiddle)
            UnitFormationHelper.ApplyFormationCentering(ref unitPositions, row, _spread);

        return unitPositions;
    }
}
