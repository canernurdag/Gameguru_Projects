using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DefaultVirtualCameraController : MonoBehaviour, IVirtualCameraController
{
	public void SetOrthoSize(CinemachineVirtualCamera vCam, float totalWidth)
	{
		string[] res = UnityStats.screenRes.Split('x');
		float screenHeight = int.Parse(res[1]);
		float screenWidth = int.Parse(res[0]);

		float screenRatio = (float)screenHeight / (float)screenWidth;
		if(screenHeight >= screenWidth)
		{
			vCam.m_Lens.OrthographicSize = totalWidth * (screenRatio) * 0.5f;
		}

		else if(screenHeight < screenWidth)
		{
			vCam.m_Lens.OrthographicSize = totalWidth / 2;
		}

		
	}
}
