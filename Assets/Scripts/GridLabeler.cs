using System.Collections.Generic;
using UnityEngine;

namespace Becloned
{
    public class GridLabeler : MonoBehaviour
    {
        public GameObject[,] LabelArray { get; private set; }

        private void Start()
        {
            InitializeLabelArray();
        }

        private void InitializeLabelArray()
        {
            NodeManager nodeManager = FindObjectOfType<NodeManager>();

            LabelArray = new GameObject[(int)nodeManager.GridSize.x, (int)nodeManager.GridSize.y];
        }

        public void SetLabel(List<GameObject> nodes)
        {
            int nodeCount = 0;

            for (int i = 0; i < LabelArray.GetLength(0); i++)
            {
                for (int j = 0; j < LabelArray.GetLength(0); j++)
                {
                    LabelArray[i, j] = nodes[nodeCount];
                    nodeCount++;
                }
            }
        }

        public Vector2 SearchNode(GameObject node)
        {
            for (int i = 0; i < LabelArray.GetLength(0); i++)
            {
                for (int j = 0; j < LabelArray.GetLength(1); j++)
                {
                    if (node.Equals(LabelArray[i, j]))
                    {
                        return new Vector2(i, j);
                    }
                }                
            }

            return new Vector2(-1, -1);
        }
    }
}

