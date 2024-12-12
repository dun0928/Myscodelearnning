Shader "Custom/SpriteGradient" {
    Properties {
        _Color ("Left Color", Color) = (1,1,1,1)
        _Color2 ("Right Color", Color) = (1,1,1,1)
        _Scale ("Scale", Float) = 1

        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _ColorMask ("Color Mask", Float) = 15
    }
     
    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 100
     
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass {
            CGPROGRAM
            #pragma vertex vert  
            #pragma fragment frag
            #include "UnityCG.cginc"
     
            fixed4 _Color;
            fixed4 _Color2;
            fixed  _Scale;
     
            struct v2f {
                float4 pos : SV_POSITION;
                fixed4 col : COLOR;
            };
     
            v2f vert (appdata_full v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                // 线性插值两个颜色，保留输入透明度
                o.col = lerp(_Color, _Color2, v.texcoord.x);
                return o;
            }
           
            float4 frag (v2f i) : COLOR {
                return i.col; // 返回插值后的颜色
            }
            ENDCG
        }
    }
}