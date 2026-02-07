using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlPanelLights : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_Animate_003Ed__4 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ControlPanelLights _003C_003E4__this;

		private int _003Cl_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003C_Animate_003Ed__4(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public Texture[] emissions;

	public Material targetMat;

	private static readonly int _emissionMap;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003C_Animate_003Ed__4))]
	private IEnumerator<float> _Animate()
	{
		return null;
	}
}
