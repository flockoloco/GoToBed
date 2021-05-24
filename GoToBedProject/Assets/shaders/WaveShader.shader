Shader "Project/Wave"{
	Properties{
		_Color("Colour", Color) = (0,0,0,1)
		_Strength("Strength", Range(0, 2)) = 1.0
		_Speed("Speed", Range(-200, 200)) = 100
	}

	SubShader{
	Tags
	{
		"RenderType" = "Transparent"
	}
		Pass  {

			Cull Off
			CGPROGRAM

			#pragma vertex MyVertexProgram
			#pragma fragment MyFragmentProgram

			float4 _Color;
			float _Strength;
			float _Speed;

			struct vertexInput {
				float4 vertex : POSITION;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
			};

			vertexOutput MyVertexProgram(vertexInput IN) {
				vertexOutput o;

				float4 worldPos = mul(unity_ObjectToWorld, IN.vertex);
				float displacement = (sin(worldPos.y + (_Speed * _Time)));
				worldPos.y = worldPos.y + (displacement * _Strength);

				o.pos = mul(UNITY_MATRIX_VP, worldPos);

				return o;
			}

			float4 MyFragmentProgram(vertexOutput IN) : COLOR{
				return _Color;
			}
			ENDCG
		}
	}
}