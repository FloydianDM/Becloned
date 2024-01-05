using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Becloned
{
    public class GameLogic : MonoBehaviour
    {
        private GridLabeler _gridLabeler;
        private NodeManager _nodeManager;
        private NodeHandler _nodeHandler;

        private void Start()
        {
            _gridLabeler = FindObjectOfType<GridLabeler>();
            _nodeManager = FindObjectOfType<NodeManager>();
            _nodeHandler = FindObjectOfType<NodeHandler>();
        }

        private void Update()
        {
            if (_nodeManager.IsReady)
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
            }
            else if (_nodeHandler.SelectedNodes[1] == null && !_nodeHandler.AdjacentNodes.Contains(node))
            {
                // player clicked to a wrong node, clear temporary arrays!
                Debug.Log("Arrays cleared");
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

                        Debug.Log("Matched");
                        _nodeManager.IsReady = false;
                        
                        return;
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
                        
                        Debug.Log("Matched");
                        _nodeManager.IsReady = false;

                        return;
                    }
                }
            }

            _nodeManager.IsReady = false;
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
    }   
}

