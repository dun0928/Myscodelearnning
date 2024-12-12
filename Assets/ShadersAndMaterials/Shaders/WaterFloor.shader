Shader "Custom/WaterFloor"
{
    Properties
    {
        _RainColor("Water Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _Normal("Normal",2D) = "bump"{}
        [NoScaleOffset]_RippleTex("Ripple Tex", 2D) = "white" {}
        [NoScaleOffset]_MaskTex("Mask Tex", 2D) = "white" {}
        _RippleScale("Ripple Scale",Range(1,10)) = 1
        _Glossiness("Smoothness", Range(0,1)) = 0.5
        _Metallic("Metallic", Range(0,1)) = 0.0
        _Ripple("Ripple Strength", Range(0,1)) = 0.0
        _WaterRange("Water Range", Range(0,1)) = 0.0
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Standard fullforwardshadows
            #pragma target 3.0

            sampler2D _MainTex;
            sampler2D _Normal;
            sampler2D _RippleTex;
            //Rͨ���������������ɵķ�Χ�����Ҵ��е�����Ч����
            //GB����ͨ���Ǹ߶ȣ������Ƿ���ͼ��Ч����
            //Aͨ�������洢ʱ���Ӱ׵��ڲ�ͬ����ɫֵ�����˲�ͬ��ʱ�䡣
            sampler2D _MaskTex;

            struct Input
            {
                half2 uv_MainTex;
                half2 uv_Normal;
                half2 uv_FlowMap;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _RainColor;
            half _RippleScale;
            half _Ripple;
            half _WaterRange;

            UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_INSTANCING_BUFFER_END(Props)

            half3 ComputeRipple(half2 uv,half t)
            {
                //������ͼ���������Ѳ����ĸ߶�ֵ��չ��-1��1
                half4 ripple = tex2D(_RippleTex,uv);
                ripple.gb = ripple.gb * 2 - 1;
                //��ȡ���Ƶ�ʱ��,��Aͨ����ȡ��ͬ�Ĳ���ʱ��,
                //frac��������ֵ��С�����֡�
                half dropFrac = frac(ripple.a + t);
                //��ʱ��������Rͨ����,(dropFrac-1+ripple.r<0ʱ������finalʱ0*UNITY_PI)
                half timeFrac = dropFrac - 1 + ripple.r;
                //����������
                half dropFactor = 1 - saturate(dropFrac);
                //�������յĸ߶ȣ���һ��sin�������ʱ���������޸�һ��ֵ��֪��ʲôЧ����
                half final = dropFactor * sin(clamp(timeFrac * 9,0,4) * UNITY_PI);
                return half3(ripple.gb * final,1);
            }

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                half3 ripple = ComputeRipple(IN.uv_MainTex * _RippleScale,_Time.y) * _Ripple;
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                half3 normal = UnpackNormal(tex2D(_Normal,IN.uv_MainTex));
                fixed mask = tex2D(_MaskTex,IN.uv_Normal).r;

                half rainMask = pow(saturate(lerp(-0.6,3,_WaterRange) - (1 - mask) * 2),8);

                fixed3 waterColor = _RainColor.rgb * c.rgb;
                o.Albedo = lerp(c.rgb,waterColor,rainMask);
                o.Normal = normalize(lerp(normal,half3(0,0,1),rainMask) + ripple * rainMask);
                o.Metallic = lerp(_Metallic,0.5,rainMask);
                o.Smoothness = lerp(_Glossiness,1,rainMask);
                o.Alpha = c.a;
            }
            ENDCG
        }
        FallBack "Diffuse"
}
