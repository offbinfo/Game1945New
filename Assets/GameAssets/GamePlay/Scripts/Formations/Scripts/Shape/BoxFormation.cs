using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class BoxFormation : FormationBase {
    [Header("Box Formation")]
    //[SerializeField] private int _columnCount = 5;
    [SerializeField] private bool _centerUnits = true;
    [SerializeField] private bool _pivotInMiddle = true;
    [SerializeField] private bool _hollow = false;
    [SerializeField] private float _nthOffset = 0;
   
    public override List<Vector3> GetPositions()
    {
        List<int> indicesToRemove = GetHolePositions();

        List<Vector3> unitPositions = new List<Vector3>();
        var unitsPerRow = Mathf.Min(_columnCount, _posCount);
        float offsetX = (unitsPerRow - 1) * _spread / 2f;

        if (unitsPerRow == 0)
        {
            return new List<Vector3>();
        }

        float rowCount = _posCount / _columnCount + (_posCount % _columnCount > 0 ? 1 : 0);
        float x, y, column;
        int firstIndexInRow;

        for (int row = 0; unitPositions.Count < _posCount; row++)
        {
            // Check if centering is enabled and if row has less than maximum
            // allowed units within the row.
            firstIndexInRow = row * _columnCount;
            if (_centerUnits &&
                row != 0 &&
                firstIndexInRow + _columnCount > _posCount)
            {
                // Alter the offset to center the units that do not fill the row
                var emptySlots = firstIndexInRow + _columnCount - _posCount;
                offsetX -= emptySlots / 2f * _spread;
            }

            for (column = 0; column < _columnCount; column++)
            {
                if (_hollow && row != 0 && row != rowCount - 1 && column != 0 && column != _columnCount - 1) continue;
                if (firstIndexInRow + column < _posCount)
                {
                    x = column * _spread - offsetX;
                    y = row * _spread;

                    Vector3 newPosition = new Vector3(x + (row % 2 == 0 ? 0 : _nthOffset), -y, 0) + transform.position;
                    unitPositions.Add(newPosition);
                }
                else
                {
                    if (_pivotInMiddle)
                        UnitFormationHelper.ApplyFormationCentering(ref unitPositions, rowCount, _spread);
                    return unitPositions.Where((item, index) => !indicesToRemove.Contains(index)).ToList();
                }
            }
        }

        if (_pivotInMiddle)
            UnitFormationHelper.ApplyFormationCentering(ref unitPositions, rowCount, _spread);
        return unitPositions.Where((item, index) => !indicesToRemove.Contains(index)).ToList();
    }
}