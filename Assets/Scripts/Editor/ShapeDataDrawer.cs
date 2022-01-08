using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShapeData) , false)]
[CanEditMultipleObjects]
[System.Serializable]
public class ShapeDataDrawer : Editor
{
    private ShapeData _shapeDataInstance => target as ShapeData;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ClearBoardButton();
        EditorGUILayout.Space();

        DrawColumnsInputFeilds();
        EditorGUILayout.Space();

        if(_shapeDataInstance.board != null && _shapeDataInstance.columns >0 && _shapeDataInstance.rows > 0)
        {
            DrawBoardTable();
        }
        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(_shapeDataInstance);
        }
    }

    private void ClearBoardButton()
    {
        if(GUILayout.Button("Clear Board"))
        {
            _shapeDataInstance.Clear();
        }
    }

    private void DrawColumnsInputFeilds()
    {
        var columnsTemp = _shapeDataInstance.columns;
        var rowsTemp = _shapeDataInstance.rows;

        _shapeDataInstance.columns = EditorGUILayout.IntField("Columns", _shapeDataInstance.columns);
        _shapeDataInstance.rows = EditorGUILayout.IntField("Rows" , _shapeDataInstance.rows);

        if((_shapeDataInstance.columns != columnsTemp || _shapeDataInstance.rows != rowsTemp) 
            && _shapeDataInstance.columns>0 && _shapeDataInstance.rows >0
            )
        {
            _shapeDataInstance.CreateNewBoard();
        }
    }

    private void DrawBoardTable()
    {
        var tableStyle = new GUIStyle("box");
        tableStyle.padding = new RectOffset(10, 10, 10, 10);
        tableStyle.margin.left = 32;

        var headerColumnStye = new GUIStyle();
        headerColumnStye.fixedWidth = 65;
        headerColumnStye.alignment = TextAnchor.MiddleCenter;

        var rowStyle = new GUIStyle();
        rowStyle.fixedHeight = 25;
        rowStyle.alignment = TextAnchor.MiddleCenter;

        var dataFieldStyle = new GUIStyle(EditorStyles.miniButtonMid);
        dataFieldStyle.normal.background = Texture2D.grayTexture;
        dataFieldStyle.onNormal.background = Texture2D.whiteTexture;

        for(var row = 0; row< _shapeDataInstance.rows; row++)
        {
            EditorGUILayout.BeginHorizontal(headerColumnStye);
            for(var column = 0; column < _shapeDataInstance.columns; column++)
            {
                EditorGUILayout.BeginHorizontal(rowStyle);
                var data = EditorGUILayout.Toggle(_shapeDataInstance.board[row].column[column], dataFieldStyle);

                _shapeDataInstance.board[row].column[column] = data;
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndHorizontal();
        }

    }

}


