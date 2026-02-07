Shader "Shader Graphs/AmnesticCloudDecal" {
	Properties {
		_RadiusPercent ("RadiusPercent", Float) = 0.8
		_StatusPercent ("StatusPercent", Range(0, 1)) = 1
		_MinPercent ("MinPercent", Range(0, 1)) = 0.1
		_Thickness ("Thickness", Float) = 0.02
		_GradientPower ("GradientPower", Float) = 1.8
		[NoScaleOffset] _SampleTexture2D_191dc57fa34f4cb9857e460eee6a3d59_Texture_1 ("Texture2D", 2D) = "white" {}
		[HideInInspector] _DrawOrder ("Draw Order", Float) = 0
		[Enum(Depth Bias, 0, View Bias, 1)] [HideInInspector] _DecalMeshBiasType ("Float", Float) = 0
		[HideInInspector] _DecalMeshDepthBias ("DecalMesh DepthBias", Float) = 0
		[HideInInspector] _DecalMeshViewBias ("DecalMesh ViewBias", Float) = 0
		[HideInInspector] _DecalStencilWriteMask ("Float", Float) = 0
		[HideInInspector] _DecalStencilRef ("Float", Float) = 0
		[ToggleUI] [HideInInspector] _AffectAlbedo ("Boolean", Float) = 1
		[ToggleUI] [HideInInspector] _AffectEmission ("Boolean", Float) = 1
		[HideInInspector] _DecalColorMask0 ("Float", Float) = 0
		[HideInInspector] _DecalColorMask1 ("Float", Float) = 0
		[HideInInspector] _DecalColorMask2 ("Float", Float) = 0
		[HideInInspector] _DecalColorMask3 ("Float", Float) = 0
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
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
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}