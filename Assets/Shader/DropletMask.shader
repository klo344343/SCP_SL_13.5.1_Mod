Shader "DropletMask" {
	Properties {
		[Enum(Off,0,Front,1,Back,2)] _CullMode ("Culling", Float) = 2
		[Toggle] _ZWriteMode ("Write to Z-buffer", Float) = 1
		[Enum(Less,0,Greater,1,LEqual,2,GEqual,3,Equal,4,NotEqual,5,Always,6)] _ZTestMode ("Depth Test", Float) = 6
		_AlphaMask ("Alpha Mask", 2D) = "white" {}
		_Normal ("Normal", 2D) = "bump" {}
		_Intensity ("Intensity", Float) = 1
		_Fade ("Opacity", Range(0, 1)) = 1
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
	Fallback "Diffuse"
	//CustomEditor "ShaderForgeMaterialInspector"
}