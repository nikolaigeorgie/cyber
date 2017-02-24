Shader "KrKr/LightingFix" {
    Properties {
        _TintColor ("TintColor", Color) = (0,0.8344831,1,1)
        _MainTexture ("MainTexture", 2D) = "white" {}
        _Glow ("Glow", Range(0, 2)) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TintColor;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float _Glow;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
//Emissive:
                float4 node_237 = _TintColor;
                float3 emissive = (_Glow*node_237.rgb);
                float3 finalColor = emissive;
                float2 node_449 = i.uv0;
//Final Color:
                return fixed4(finalColor,(node_237.a*tex2D(_MainTexture,TRANSFORM_TEX(node_449.rg, _MainTexture)).a));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
