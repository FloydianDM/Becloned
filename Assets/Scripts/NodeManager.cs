using System.Collections.Generic;
using UnityEngine;

namespace Becloned
{
    public class NodeManager : MonoBehaviour
    {
        [SerializeField] private GameObject _nodePrefab;
        [SerializeField] private GameObject _firstNode;
        [SerializeField] private Transform _parentTransform;
        
        private Vector2 _gridSize = new Vector2(8,8);
        public Vector2 GridSize => _gridSize;
        private RectTransform _firstNodeRectTransform;
        private List<GameObject> _nodes = new List<GameObject>();
        private NodeHandler _nodeHandler;
        private GridLabeler _gridLabeler;
        public bool IsReady;

        private void Start()
        {  
            _nodeHandler = GetComponent<NodeHandler>();
            _gridLabeler = FindObjectOfType<GridLabeler>();           
            _firstNodeRectTransform = _firstNode.GetComponent<RectTransform>();    

            CreateGrid();
            SetNodeColor();
        }

        private void CreateGrid()
        {
            Vector2 gridSizeMultiplier = new Vector2(800,800) / _gridSize;

            for (int j = 0; j < _gridSize.y; j++)
            {
                for (int i = 0; i < _gridSize.x; i++)
                {
                    float nodePositionX = _firstNodeRectTransform.position.x + (i * gridSizeMultiplier.x);
                    float nodePositionY = _firstNodeRectTransform.position.y - (j * gridSizeMultiplier.y);
                    Vector3 newPosition = new Vector3(nodePositionX,nodePositionY);
                    
                    GameObject node = Instantiate(_nodePrefab, _parentTransform);
                    RectTransform nodeRectTransform = node.GetComponent<RectTransform>();
                    nodeRectTransform.anchoredPosition = new Vector2(0,0);
                    nodeRectTransform.position = newPosition;
                    
                    _nodes.Add(node);
                }
            }

            Destroy(_firstNode); // job done
            _gridLabeler.SetLabel(_nodes);
        }

        private void SetNodeColor()
        {
            foreach (GameObject node in _nodes)
            {
                _nodeHandler.SetRandomColor(node);
            }

            IsReady = true;            
        }  
    }
}
