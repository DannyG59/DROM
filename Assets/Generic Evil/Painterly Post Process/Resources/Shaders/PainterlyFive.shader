    // Painterly Post Process
    // Copyright 2014 Generic Evil Business Ltd.
    // http://www.genericevil.com
    Shader "Hidden/Generic Evil/Painterly/PainterlyFive" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader 
	{
		ZTest Always Cull Off ZWrite Off
		Fog { Mode off }
		ColorMask RGB

		Pass 
		{
			CGPROGRAM
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex PainterlyVert
			#pragma fragment PainterlyFragment

			#define MAX
			#define FIVE_SAMPLE

			#include "UnityCG.cginc"
			#include "../PainterlyLib.cginc"
			ENDCG
		}
	} 
	FallBack "Diffuse"
}