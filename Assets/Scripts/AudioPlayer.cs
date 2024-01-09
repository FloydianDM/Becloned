using UnityEngine;

namespace Becloned
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _nodeSFX;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayNodeSFX()
        {
            _audioSource.PlayOneShot(_nodeSFX);           
        }
    }

}
