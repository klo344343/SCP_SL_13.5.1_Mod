using UnityEngine;
using UnityEngine.UI;

namespace VoiceChat
{
	public class UiWaveformVisualizer : Graphic
	{
		private float[] _recordedAverages;

		[field: SerializeField]
		public ushort RenderersCount { get; internal set; }

		[field: SerializeField]
		public float FlatlineHeight { get; internal set; }

		[field: SerializeField]
		public bool TwoSidedMode { get; internal set; }

		[field: SerializeField]
		public float MaxNormalizer { get; internal set; }

		[field: SerializeField]
		public AnimationCurve CorrectionCurve { get; internal set; }

		public void Generate(float[] samples)
		{
		}

		public void Generate(float[] samples, int startIndex, int length)
		{
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
		}

		private void DrawWaveform(UIVertex vert, float rectWidth, float rectHeight, VertexHelper vh)
		{
		}
	}
}
