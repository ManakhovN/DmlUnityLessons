Shader "Hidden/ShakeEffect"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_OffsetX("OffsetX", Range(0,1)) = 0
		_OffsetY("OffsetY", Range(0, 1)) = 0
	}

		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				float _OffsetX; //Смещение по X
				float _OffsetY; //Смещение по Y
				float2 screenUV;
				fixed4 frag(v2f i) : SV_Target //Функция шейдера
				{
					fixed4 col = tex2D(_MainTex, i.uv); //Получаем текущий пиксель изображения
					float2 pos = i.uv; // Получаем координаты текущего пикселя.
					
					fixed4 gradient = fixed4((i.uv.y+i.uv.x) / 2.0, (i.uv.y+i.uv.x) / 2.0, (i.uv.y+i.uv.x)/2.0, 1);
					
					return col*gradient; //Возвращаем полученный цвет
				}
				ENDCG
			}
		}
}
