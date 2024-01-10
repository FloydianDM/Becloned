using UnityEngine;

namespace Becloned
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioClip _nodeSFX;
        [SerializeField] private AudioClip _successSFX;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayNodeSFX()
        {
            _audioSource.PlayOneShot(_nodeSFX);           
        }

        public void PlaySuccessSFX()
        {
            _audioSource.PlayOneShot(_successSFX);
        }
    }

}
