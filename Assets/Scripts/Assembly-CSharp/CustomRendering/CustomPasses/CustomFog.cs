using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class CustomFog : CustomPass
{
    private readonly int _fogColorId = Shader.PropertyToID("_CustomFogColor");
    private readonly int _distanceParamsId = Shader.PropertyToID("_DistanceParams");

    [ColorUsage(false, true)]
    public Color FogColor = Color.black;

    [Range(0f, 1f)]
    public float FadeIntensity = 1f;

    public float EndDistance = 200f;

    public float StartDistance = 0f;

    [Range(0f, 1f)]
    public float CoverSkybox = 1f;

    private Material _fogMaterial;

    protected override void Setup(ScriptableRenderContext renderContext, CommandBuffer cmd)
    {
        Shader shader = Shader.Find("Hidden/Renderers/CustomFog");
        if (shader != null)
        {
            this._fogMaterial = CoreUtils.CreateEngineMaterial(shader);
        }
    }

    protected override void Execute(CustomPassContext ctx)
    {
        if (this._fogMaterial == null) return;

        base.SetRenderTargetAuto(ctx.cmd);

        this._fogMaterial.SetColor(this._fogColorId, this.FogColor);
        this._fogMaterial.SetVector(this._distanceParamsId, new Vector4(this.StartDistance, this.EndDistance, this.FadeIntensity, this.CoverSkybox));

        CoreUtils.DrawFullScreen(ctx.cmd, this._fogMaterial, null, 0);
    }

    public override IEnumerable<Material> RegisterMaterialForInspector()
    {
        if (this._fogMaterial != null)
        {
            yield return this._fogMaterial;
        }
    }

    protected override void Cleanup()
    {
        CoreUtils.Destroy(this._fogMaterial);
    }
}