using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Becloned
{
    public class VFXPlayer : MonoBehaviour
    {
        [SerializeField] private Sprite _explosionSprite;

        public IEnumerator PlayExplosionVFX(GameObject node)
        {
            Image nodeImage = node.GetComponentInChildren<Image>();

            nodeImage.sprite = _explosionSprite;
            Debug.Log("Explode");

            yield return new WaitForSeconds(0.5f);

            nodeImage.sprite = null;
        }
    }
}
