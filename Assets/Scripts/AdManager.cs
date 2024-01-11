using UnityEngine;
using UnityEngine.Advertisements;

namespace Becloned
{
    public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private string _androidGameId = "5523408";
        private string _iOSGameId = "5523409";
        private bool _isTestMode = true;
        private string _androidAdUnitId = "Rewarded_Android";
        private string _iOSAdUnitId = "Rewarded_iOS";

        public static AdManager Instance;

        private string _gameId;
        private string _adUnitId;
        private GameManager _gameManager;

        private void Awake()
        {
            ManageSingleton();
        }

        private void ManageSingleton()
        {
            if (Instance != null && Instance != this)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
            {
                InitializeAds();

                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void InitializeAds()
        {
    #if UNITY_IOS
            _gameId = _iOSGameId;
            _adUnitId = _iOSAdUnitId;
    #elif UNITY_ANDROID
            _gameId = _androidGameId;
            _adUnitId = _androidAdUnitId;
    #elif UNITY_EDITOR
            _gameId = _androidGameId;
            _adUnitId = _androidAdUnitId;
    #endif

            if (!Advertisement.isInitialized)
            {
                Advertisement.Initialize(_gameId, _isTestMode, this);
            }            
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Ad Initialization Complete");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log("Ad Initialization Failed");
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Advertisement.Show(placementId, this);
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            Debug.Log("Ad Load Failed");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log("Ad Show Failed");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            throw new System.NotImplementedException();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED))
            {
                // reward player - add time

                Debug.Log("AD WATCHED!");
                TimeManager timeManager = FindObjectOfType<TimeManager>();
                timeManager.SetTimer(400);
            }
        }

        public void ShowAd(GameManager gameManager)
        {
            _gameManager = gameManager;

            Advertisement.Load(_adUnitId, this);           
        }
    }
}

