Shader "Shader Graphs/DissolveDecal" {
	Properties {
		_BaseColor ("BaseColor", Vector) = (0,0,0,0)
		[NoScaleOffset] _BaseColorMap ("BaseColorMap", 2D) = "white" {}
		[NoScaleOffset] _MaskMap ("MaskMap", 2D) = "white" {}
		[NoScaleOffset] _NormalMap ("NormalMap", 2D) = "white" {}
		_Dissolve ("Dissolve", Range(0, 1)) = 0
		_NoiseScale ("NoiseScale", Float) = 14.63
		_DissolvePower ("DissolvePower", Float) = 2.26
		_Cutoff ("Cutoff", Float) = 0
		[NoScaleOffset] _HDRPLit_38ee15cdfb4b4f5fbb78428d4de55ad6_DetailMap_913208011 ("Texture2D", 2D) = "white" {}
		[NoScaleOffset] _HDRPLit_38ee15cdfb4b4f5fbb78428d4de55ad6_EmissiveColorMap_243130236 ("Texture2D", 2D) = "white" {}
		[NoScaleOffset] _SampleTexture2D_a820a06de00344b183b8d7270273b27f_Texture_1 ("Texture2D", 2D) = "white" {}
		[HideInInspector] _DrawOrder ("Draw Order", Float) = 0
		[Enum(Depth Bias, 0, View Bias, 1)] [HideInInspector] _DecalMeshBiasType ("Float", Float) = 0
		[HideInInspector] _DecalMeshDepthBias ("DecalMesh DepthBias", Float) = 0
		[HideInInspector] _DecalMeshViewBias ("DecalMesh ViewBias", Float) = 0
		[HideInInspector] _DecalStencilWriteMask ("Float", Float) = 0
		[HideInInspector] _DecalStencilRef ("Float", Float) = 0
		[ToggleUI] [HideInInspector] _AffectAlbedo ("Boolean", Float) = 1
		[ToggleUI] [HideInInspector] _AffectNormal ("Boolean", Float) = 1
		[ToggleUI] [HideInInspector] _AffectMetal ("Boolean", Float) = 1
		[ToggleUI] [HideInInspector] _AffectSmoothness ("Boolean", Float) = 1
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