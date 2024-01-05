using System;
using UnityEngine;
using UnityEngine.UI;

namespace Becloned
{
    public enum ColorCode
    {
        blue,
        green,
        red,
        yellow,
        magenta,
        cyan,
        black,
    }

    public class NodeHandler : MonoBehaviour
    {
        // temporary arrays for changing colors of the selected nodes
        public GameObject[] SelectedNodes = new GameObject[2];
        public GameObject[] AdjacentNodes = new GameObject[4];

        private void SetElementTag(GameObject node, ColorCode colorCode)
        {
            switch (colorCode)
            {
                case ColorCode.blue:
                    node.tag = "Blue";
                    break;
                case ColorCode.green:
                    node.tag = "Green";
                    break;
                case ColorCode.red:
                    node.tag = "Red";
                    break;
                case ColorCode.yellow:
                    node.tag = "Yellow";
                    break;
                case ColorCode.magenta:
                    node.tag = "Magenta";
                    break;
                case ColorCode.cyan:
                    node.tag = "Cyan";
                    break;
                case ColorCode.black:
                    node.tag = "Black";
                    break;
            }
        }

        public void SetRandomColor(GameObject node)
        {
            int colorNumber = UnityEngine.Random.Range(0,7);

            switch (colorNumber)
            {
                case 0:
                    node.GetComponentInChildren<Image>().color = Color.blue;
                    SetElementTag(node, ColorCode.blue);
                    break;
                case 1:
                    node.GetComponentInChildren<Image>().color = Color.green;
                    SetElementTag(node, ColorCode.green);
                    break;
                case 2:
                    node.GetComponentInChildren<Image>().color = Color.red;
                    SetElementTag(node, ColorCode.red);
                    break;
                case 3:
                    node.GetComponentInChildren<Image>().color = Color.yellow;
                    SetElementTag(node, ColorCode.yellow);
                    break;
                case 4:
                    node.GetComponentInChildren<Image>().color = Color.magenta;
                    SetElementTag(node, ColorCode.magenta);
                    break;
                case 5:
                    node.GetComponentInChildren<Image>().color = Color.cyan;
                    SetElementTag(node, ColorCode.cyan);
                    break;
                case 6:
                    node.GetComponentInChildren<Image>().color = Color.black;
                    SetElementTag(node, ColorCode.black);
                    break;
            }
        }
        
        public void ChangeColor(GameObject firstNode, GameObject secondNode)
        {
            Color firstNodeColor = firstNode.GetComponentInChildren<Image>().color;
            string firstNodeTag = firstNode.tag;
            Color secondNodeColor = secondNode.GetComponentInChildren<Image>().color;
            string secondNodeTag = secondNode.tag;

            firstNode.GetComponentInChildren<Image>().color = secondNodeColor;
            firstNode.tag = secondNodeTag;
            secondNode.GetComponentInChildren<Image>().color = firstNodeColor;
            secondNode.tag = firstNodeTag;

            // job done, clear the temporary arrays!
            ClearArrays();
        }

        public void ClearArrays()
        {
            Array.Clear(SelectedNodes, 0, SelectedNodes.Length); 
            Array.Clear(AdjacentNodes, 0, AdjacentNodes.Length); 
        }
    }
}

