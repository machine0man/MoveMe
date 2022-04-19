using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;
using System;


public class AdManager : MonoBehaviour
{

    static AdManager s_Instance;

	#region Unity Methods
	void Awake()
	{
		s_Instance = this;
	}
	void OnDestroy()
	{
		s_Instance = null;
	}

	#endregion



	/*

		string rewardedAdId = "ca-app-pub-9392546140437202/8174016294"; 
		string t_rewardedAdId = "ca-app-pub-3940256099942544/5224354917";
		private RewardedAd rewardedAd;
	   public void Start()
		{
			// Initialize the Google Mobile Ads SDK.
			MobileAds.Initialize(initStatus => { });

			this.rewardedAd = new RewardedAd(t_rewardedAdId);



			 // Called when an ad request has successfully loaded.
			this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
			// Called when an ad request failed to load.
			this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
			// Called when an ad is shown.
			this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
			// Called when an ad request failed to show.
			this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
			// Called when the user should be rewarded for interacting with the ad.
			this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
			// Called when the ad is closed.
			this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;



			// Create an empty ad request.
			AdRequest request = new AdRequest.Builder().Build();
			// Load the rewarded ad with the request.
			this.rewardedAd.LoadAd(request);
		}



		public void HandleRewardedAdLoaded(object sender, EventArgs args)
		{
		   Debug.Log("HandleRewardedAdLoaded event received");
		}

		public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
		{
			Debug.Log("HandleRewardedAdFailedToLoad event received with message: " + args.Message);
		}

		public void HandleRewardedAdOpening(object sender, EventArgs args)
		{
			Debug.Log("HandleRewardedAdOpening event received");
		}

		public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
		{
			Debug.Log( "HandleRewardedAdFailedToShow event received with message: " + args.Message);
		}

		public void CreateAndLoadRewardedAd()
		{
			this.rewardedAd = new RewardedAd(t_rewardedAdId);

			this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
			this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
			this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

			// Create an empty ad request.
			AdRequest request = new AdRequest.Builder().Build();
			// Load the rewarded ad with the request.
			this.rewardedAd.LoadAd(request);
		}
		public void HandleRewardedAdClosed(object sender, EventArgs args)
		{
			Debug.Log("HandleRewardedAdClosed event received");
			this.CreateAndLoadRewardedAd();
		}

		public void HandleUserEarnedReward(object sender, Reward args)
		{
			string type = args.Type;
			double amount = args.Amount;
			Debug.Log("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
		}

		private void UserChoseToWatchAd()
		{
		  if (this.rewardedAd.IsLoaded()) {
			this.rewardedAd.Show();
		  }
		}
		public void RunAd()
		{
			UserChoseToWatchAd();

		}*/

}
