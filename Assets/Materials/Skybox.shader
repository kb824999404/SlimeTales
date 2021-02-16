Shader "MyShaders/Skybox"
{
    Properties
    {
        _Color1 ("Color1",Color) = (0,0,0,1)
        _Color2 ("Color2",Color) = (0.5,0.5,0.5,1)
        _Color3 ("Color3",Color) = (1,1,1,1)
        _MidValue("MidValue",Range(0,1)) = 0.5
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            fixed4 _Color1;
            fixed4 _Color2;
            fixed4 _Color3;
            float _MidValue;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            //天空颜色
            fixed4 skyColor(in float2 uv)
            {
                float curValue = uv.y;
                curValue = (curValue + 1.0)/2.0;

                // //是否大于中间值
                half greaterMid = step(_MidValue,curValue);

                float lerpValue1 = curValue;
                float lerpValue2 = curValue - _MidValue;
                
                lerpValue1 = lerpValue1 / _MidValue;
                lerpValue2 = lerpValue2 / (1.0 - _MidValue);



                fixed4 lerpColor1 = lerp(_Color1,_Color2,lerpValue1);
                fixed4 lerpColor2 = lerp(_Color2,_Color3,lerpValue2);


                fixed4 color = (1.0-greaterMid) * lerpColor1 + greaterMid * lerpColor2;

                return color;
            }

            fixed4 frag (v2f i) : SV_Target
            {

                fixed4 col =  skyColor(i.uv);

            
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                // fixed4 test = fixed4(curValue,0,0,1.0);
                return col;
            }

            ENDCG
        }
    }
}
