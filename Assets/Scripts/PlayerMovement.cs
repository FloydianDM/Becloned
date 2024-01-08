using UnityEngine;
using UnityEngine.EventSystems;

namespace Becloned
{
    public class PlayerMovement : MonoBehaviour, IPointerDownHandler
    {
        private GameObject _node;
        private GameLogic _gameLogic;

        private void Start()
        {
            _gameLogic = FindObjectOfType<GameLogic>();
            _node = this.gameObject;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _gameLogic.SelectElement(_node);
        }
    }
}

