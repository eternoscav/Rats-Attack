using UnityEngine;
using System.Collections;

public class Banner : MonoBehaviour {

	public string PublisherId = "";
	public bool IsGrounded;
	// Use this for initialization
	void Start () {
		GoogleMobileAdsPlugin.CreateBannerView(PublisherId, GoogleMobileAdsPlugin.AdSize.SmartBanner, true);
		GoogleMobileAdsPlugin.RequestBannerAd(true);
		GoogleMobileAdsPlugin.ShowBannerView ();
	}
	public void LigarBanner(){
		if(IsGrounded = true){
		GoogleMobileAdsPlugin.ShowBannerView ();
		IsGrounded = false;
		}
		if(IsGrounded = false){
			GoogleMobileAdsPlugin.HideBannerView ();
			IsGrounded = true;
		}
		}
	

}
