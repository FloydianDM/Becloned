using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Becloned
{
    // *** known bugs ***
    // check horizontal and vertical matches simultaneously (do not use return, break maybe)
    // out of range exception on last index of array 

    // TODO: Remove points if any matches could not found after changing two elements.

    public class GameLogic : MonoBehaviour
    {
        private GridLabeler _gridLabeler;
        private NodeManager _nodeManager;
        private NodeHandler _nodeHandler;
        private ScoreManager _scoreManager;

        private void Start()
        {
            _gridLabeler = FindObjectOfType<GridLabeler>();
            _nodeManager = FindObjectOfType<NodeManager>();
            _nodeHandler = FindObjectOfType<NodeHandler>();
            _scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void Update()
        {
            if (_nodeManager.IsReadyToCheck)
            {
                CheckMatch();
            }
        }

        public void SelectElement(GameObject node)
        {
            Vector2 nodeIndex = _gridLabeler.SearchNode(node);

            if (_nodeHandler.SelectedNodes[0] == null)
            {
                _nodeHandler.SelectedNodes[0] = node;
                Debug.Log(_nodeHandler.SelectedNodes[0].tag);
                AddAdjacentNodes((int)nodeIndex.x, (int)nodeIndex.y);
            }
            else if (_nodeHandler.SelectedNodes[1] == null && _nodeHandler.AdjacentNodes.Contains(node))
            {
                _nodeHandler.SelectedNodes[1] = node;
                Debug.Log(_nodeHandler.SelectedNodes[1].tag);
                _nodeHandler.ChangeColor(_nodeHandler.SelectedNodes[0], _nodeHandler.SelectedNodes[1]);
                _nodeManager.IsReadyToCheck = true;
            }
            else if (_nodeHandler.SelectedNodes[1] == null && !_nodeHandler.AdjacentNodes.Contains(node))
            {
                // player clicked to a wrong node, clear temporary arrays!
                _nodeHandler.ClearArrays();
            }
        }

        public void CheckMatch()
        {
            // lateral check

            for (int row = 0; row < _gridLabeler.LabelArray.GetLength(0); row++)
            {
                for (int column = 0; column < _gridLabeler.LabelArray.GetLength(1)-2; column++)
                {
                    if (_gridLabeler.LabelArray[row, column].tag == _gridLabeler.LabelArray[row, column+1].tag &&
                        _gridLabeler.LabelArray[row, column+1].tag == _gridLabeler.LabelArray[row, column+2].tag)
                    {
                        // match found
                        DeleteMatchedNodes(row, column, true);
                    }
                }
            }

            // vertical check

            for (int column = 0; column < _gridLabeler.LabelArray.GetLength(1); column++)
            {
                for (int row = 0; row < _gridLabeler.LabelArray.GetLength(0)-2; row++)
                {
                    if (_gridLabeler.LabelArray[row, column].tag == _gridLabeler.LabelArray[row+1, column].tag &&
                        _gridLabeler.LabelArray[row+1, column].tag == _gridLabeler.LabelArray[row+2, column].tag)
                    {
                        // match found
                        DeleteMatchedNodes(row, column, false);
                    }
                }
            }
        }

        private void AddAdjacentNodes(int i, int j)
        {
            if (j >= 1)
            {
                _nodeHandler.AdjacentNodes[0] = _gridLabeler.LabelArray[i, j-1];
            }

            if (j <= 6)
            {
                _nodeHandler.AdjacentNodes[1] = _gridLabeler.LabelArray[i, j+1];
            }

            if (i >= 1)
            {
                _nodeHandler.AdjacentNodes[2] = _gridLabeler.LabelArray[i-1, j];
            }

            if (i <= 6)
            {
                _nodeHandler.AdjacentNodes[3] = _gridLabeler.LabelArray[i+1, j]; 
            }
        }

        private void DeleteMatchedNodes(int row, int column, bool isLateral)
        {
            // delete matched lateral nodes

            while (true && isLateral) 
            {
                if (_gridLabeler.LabelArray[row, column].tag == _gridLabeler.LabelArray[row, column+1].tag)
                {
                    ChangeNodeColor(row, column);
                    AddScore(10);

                    column++;
                }
                else
                {
                    ChangeNodeColor(row, column); // change the last matched node's color before breaking the loop
                    AddScore(10);

                    return;
                }
            }            

            // delete matched vertical nodes

            while (true && !isLateral)
            {
                if (_gridLabeler.LabelArray[row, column].tag == _gridLabeler.LabelArray[row+1, column].tag)
                {
                    ChangeNodeColor(row, column);
                    AddScore(10);

                    row ++;
                }
                else
                {
                    ChangeNodeColor(row, column); // change the last matched node's color before breaking the loop
                    AddScore(10);

                    return;
                }
            }           
        }

        private void ChangeNodeColor(int row, int column)
        {
            GameObject node = _gridLabeler.LabelArray[row, column];
            _nodeHandler.SetRandomColor(node);
        }

        private void AddScore(int points)
        {
            if (_nodeManager.IsReadyToCountScore)
            {
                _scoreManager.ChangeScore(points);
            }
        }
    }   
}

