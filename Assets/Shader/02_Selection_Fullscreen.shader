Shader "02_Selection/Fullscreen" {
	Properties {
		_SamplePrecision ("Sampling Precision", Range(1, 3)) = 1
		_OutlineWidth ("Outline Width", Float) = 5
		_InnerColor ("Inner Color", Vector) = (1,1,0,0.5)
		_OuterColor ("Outer Color", Vector) = (1,1,0,1)
		_Texture ("Texture", 2D) = "black" {}
		_TextureSize ("Texture Pixels Size", Vector) = (64,64,0,0)
		_BehindFactor ("Behind Factor", Range(0, 1)) = 0.2
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
}