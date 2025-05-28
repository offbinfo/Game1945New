using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FormationRenderer))]
public abstract class FormationBase : GameMonoBehaviour {
    //[Header("Base Formation")]
    [SerializeField] protected int _posCount => _rowCount * _columnCount;
    [SerializeField] protected float _spread = 1;

    [SerializeField] string hole;
    public abstract List<Vector3> GetPositions();

    [Header("Base Formation")]
    [SerializeField] protected int _rowCount = 6;
    [SerializeField] protected int _columnCount = 5;

    [SerializeField] private TextAsset m_paintDataText;

    public int posCountExact => _rowCount * _columnCount;

    private void InitRowAndColumnFromText()
    {
        if (m_paintDataText == null)
        {
            Debug.LogWarning("m_paintDataText is null.");
            return;
        }

        string[] rawLines = m_paintDataText.text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

        if (rawLines.Length == 0)
        {
            Debug.LogWarning("Text file is empty.");
            return;
        }

        List<string> lines = new List<string>();
        foreach (string raw in rawLines)
        {
            string clean = raw.TrimEnd();
            if (!string.IsNullOrWhiteSpace(clean))
                lines.Add(clean);
        }

        _rowCount = lines.Count;
        _columnCount = lines[0].Length;

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Length != _columnCount)
            {
                Debug.LogWarning($"Line {i} length mismatch: {lines[i].Length} != expected {_columnCount}. Check your file formatting.");
            }
        }

        //Debug.Log($"Detected Rows = {_rowCount}, Columns = {_columnCount}");
    }


    protected List<int> GetHolePositions()
    {
        InitRowAndColumnFromText();

        List<int> holePositions = new List<int>();

        if (m_paintDataText != null)
        {
            string[] rawLines = m_paintDataText.text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

            if (rawLines.Length == 0)
            {
                Debug.LogWarning("Paint data is empty.");
                return holePositions;
            }

            string firstLine = rawLines[0].Trim();
            int width = firstLine.Length;

            for (int row = 0; row < rawLines.Length; row++)
            {
                string cleanLine = rawLines[row].Trim();

                if (cleanLine.Length != width)
                {
                    Debug.LogWarning($"Line {row} length ({cleanLine.Length}) != expected width ({width}). Skipping this line.");
                    continue;
                }

                for (int col = 0; col < width; col++)
                {
                    char c = cleanLine[col];
                    if (c == '-' || c == '_')
                    {
                        int index = row * width + col;
                        holePositions.Add(index);
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("m_paintDataText is null.");
        }

        return holePositions;
    }
}