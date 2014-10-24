// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Paradox Shader Mixin Code Generator.
// To generate it yourself, please install SiliconStudio.Paradox.VisualStudio.Package .vsix
// and re-save the associated .pdxfx.
// </auto-generated>

using SiliconStudio.Core;
using SiliconStudio.Paradox.Effects;
using SiliconStudio.Paradox.Shaders;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;


#line 3 "C:\Projects\Paradox\sources\shaders\CubemapBlendEffect.pdxfx"
using SiliconStudio.Paradox.Effects.Data;

#line 4
using SiliconStudio.Paradox.Effects.Modules;

#line 5
using SiliconStudio.Paradox.Effects.Modules.Renderers;

#line 7
namespace CubemapBlendShader
{

    #line 9
    public partial class SingleCubemapShader  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 11
            context.Mixin(mixin, "CubemapFaceDisplay", TexturingKeys.TextureCube0);
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("SingleCubemapShader", new SingleCubemapShader());
        }
    }

    #line 14
    public partial class CubemapBlendEffect  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSourceTree mixin, ShaderMixinContext context)
        {

            #line 20
            context.Mixin(mixin, "ShaderBase");

            #line 21
            context.Mixin(mixin, "PostEffectBase");

            #line 24
            mixin.Mixin.AddMacro("TEXTURECUBE_BLEND_COUNT", 2);

            #line 25
            context.Mixin(mixin, "CubemapBlender");

            #line 27
            foreach(var ____1 in context.GetParam(CubeMapBlender.Cubemaps))

            {

                #line 27
                context.PushParameters(____1);

                {

                    #line 29
                    var __subMixin = new ShaderMixinSourceTree() { Parent = mixin };

                    #line 29
                    context.Mixin(__subMixin, "SingleCubemapShader");
                    mixin.Mixin.AddCompositionToArray("Cubemaps", __subMixin.Mixin);
                }

                #line 27
                context.PopParameters();
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("CubemapBlendEffect", new CubemapBlendEffect());
        }
    }
}
