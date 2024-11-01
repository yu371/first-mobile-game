Shader "Custom/Gradation" {
   Properties{
       _BeforeColor("Before Color", Color) = (0,0,1,1)
       _AfterColor("After Color", Color) = (1,0,0,1)
       _BeforeColorAmount("Before Color Amount", Range(-1, 1)) = -1
   }
       
   SubShader
   {
       Tags {
       "RenderType" = "Opaque"
       "Queue" = "Transparent"
       "LightMode" = "ForwardBase"
        }

       LOD 100

           Pass{

           CGPROGRAM
           
           #pragma vertex vert
           #pragma fragment frag
           #include "UnityCG.cginc"
           #include "UnityLightingCommon.cginc"

           fixed4 _BeforeColor;
           fixed4 _AfterColor;
           fixed _BeforeColorAmount;

           struct appdata {
               half4 vertex : POSITION;
               half2 uv : TEXCOORD0;
               float3 normal : NORMAL;
           };

           struct v2f {
               half4 vertex : SV_POSITION;
               fixed4 color : COLOR0;
               half2 uv : TEXCOORD0;
           };

           v2f vert(appdata v) {
               v2f o;
               o.vertex = UnityObjectToClipPos(v.vertex);
               o.uv = v.uv;
               half3 worldNormal = UnityObjectToWorldNormal(v.normal);
               half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
               o.color = nl * _LightColor0;
               o.color.rgb += ShadeSH9(half4(worldNormal, 1));

               return o;
           }
           fixed4 frag(v2f i) : COLOR{
               fixed amount = clamp(i.uv.y + _BeforeColorAmount, 0, 1.0);
               i.color = lerp(_AfterColor, _BeforeColor, amount) * i.color;

               return i.color;
           }
           ENDCG
       }
   }
}