using UnityEngine;
using System.Collections;

public class PlayerPreferenceManager : MonoBehaviour {

	static string merge_key="merge_key";
	static string occlusion_key="occlusion_key";
	static string rotation_key = "rotation_key";
	static string zoom_key="zoom_key";
	static string transfer_key="transfer_key";

	public static void setMerge(float value)
	{
		PlayerPrefs.SetFloat (merge_key, value);
	}

	public static void setOcclusion(float value)
	{
		PlayerPrefs.SetFloat (occlusion_key, value);
	}

	public static void setRotation(float value)
	{
		PlayerPrefs.SetFloat (rotation_key, value);
	}

	public static void setZoom(float value)
	{
		PlayerPrefs.SetFloat (zoom_key, value);
	}

	public static void setTransfer(float value)
	{
		PlayerPrefs.SetFloat (transfer_key, value);
	}

	public static float getMerge()
	{
		return(PlayerPrefs.GetFloat (merge_key));
	}

	public static float getOcclusion()
	{
		return(PlayerPrefs.GetFloat (occlusion_key));
	}

	public static float getRotation()
	{
		return(PlayerPrefs.GetFloat (rotation_key));
	}

	public static float getZoom()
	{
		return(PlayerPrefs.GetFloat (zoom_key));
	}

	public static float getTransfer()
	{
		return(PlayerPrefs.GetFloat (transfer_key));
	}
}
