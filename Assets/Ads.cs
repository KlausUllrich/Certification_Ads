using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine.UI;


public class Ads : MonoBehaviour {


	private string gameID = "1661301";  // nur zum test


	Button m_Button;

	public string placementId = "rewardedVideo";




	void Start () {
		#if UNITY_ANDROID
		gameID = "1661301";
		#elif UNITY_IOS
		gameID = "1661300";
		#endif


		m_Button = GetComponent<Button> ();
		if (m_Button)
			m_Button.onClick.AddListener (ShowAd);

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameID, true);   // true for test mode
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (m_Button)
			m_Button.interactable = Advertisement.IsReady (placementId);
	}


	void ShowAd(){
		ShowOptions options = new ShowOptions ();
		options.resultCallback = HandleShowResult;
		Advertisement.Show (placementId, options);
	}


	void HandleShowResult (ShowResult result) {
		if (result == ShowResult.Finished) {
			Debug.Log ("Video completed - offer reward");
		} else if (result == ShowResult.Skipped) {
			Debug.Log ("Video was skipped - do not reward");
		} else if (result == ShowResult.Failed) {
			Debug.Log ("Video failed to show");
		}
	}

}
