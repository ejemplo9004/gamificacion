// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MorionPersonalizable"
{
	Properties
	{
		_Difuso("Difuso", 2D) = "white" {}
		_mascara1("mascara1", 2D) = "white" {}
		_mascaracabello("mascara cabello", 2D) = "white" {}
		_ColorPiel("ColorPiel", Color) = (0.8301887,0.6863893,0.5905305,1)
		_ColorRopa1("ColorRopa1", Color) = (0.8207547,0.06504088,0.06504088,0)
		_ColorRopa2("ColorRopa2", Color) = (0.3478318,0.8196079,0.06666667,0)
		_ColorCabello("ColorCabello", Color) = (0.4716981,0.3192614,0.1575293,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Difuso;
		uniform float4 _Difuso_ST;
		uniform float4 _ColorPiel;
		uniform sampler2D _mascara1;
		uniform float4 _mascara1_ST;
		uniform float4 _ColorRopa1;
		uniform float4 _ColorRopa2;
		uniform float4 _ColorCabello;
		uniform sampler2D _mascaracabello;
		uniform float4 _mascaracabello_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Difuso = i.uv_texcoord * _Difuso_ST.xy + _Difuso_ST.zw;
			float4 tex2DNode1 = tex2D( _Difuso, uv_Difuso );
			float2 uv_mascara1 = i.uv_texcoord * _mascara1_ST.xy + _mascara1_ST.zw;
			float4 tex2DNode2 = tex2D( _mascara1, uv_mascara1 );
			float4 lerpResult6 = lerp( tex2DNode1 , ( tex2DNode1 * _ColorPiel ) , tex2DNode2.r);
			float4 lerpResult9 = lerp( lerpResult6 , ( tex2DNode1 * _ColorRopa1 ) , tex2DNode2.g);
			float4 lerpResult12 = lerp( lerpResult9 , ( tex2DNode1 * _ColorRopa2 ) , tex2DNode2.b);
			float2 uv_mascaracabello = i.uv_texcoord * _mascaracabello_ST.xy + _mascaracabello_ST.zw;
			float4 lerpResult15 = lerp( lerpResult12 , ( tex2DNode1 * _ColorCabello ) , tex2D( _mascaracabello, uv_mascaracabello ).r);
			o.Albedo = lerpResult15.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18935
70.4;20.8;1281.6;763;1755.278;510.7581;2.123311;True;False
Node;AmplifyShaderEditor.SamplerNode;1;-919.6573,-389.5977;Inherit;True;Property;_Difuso;Difuso;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;4;-884.8339,-94.88701;Inherit;False;Property;_ColorPiel;ColorPiel;3;0;Create;True;0;0;0;False;0;False;0.8301887,0.6863893,0.5905305,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-538.2878,-144.9074;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;7;-890.6298,84.47503;Inherit;False;Property;_ColorRopa1;ColorRopa1;4;0;Create;True;0;0;0;False;0;False;0.8207547,0.06504088,0.06504088,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;2;-957.1525,431.6893;Inherit;True;Property;_mascara1;mascara1;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;6;-351.0846,-168.872;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-545.0594,-24.10262;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;10;-897.648,262.3752;Inherit;False;Property;_ColorRopa2;ColorRopa2;5;0;Create;True;0;0;0;False;0;False;0.3478318,0.8196079,0.06666667,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;9;-180.4507,-40.12962;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-539.0488,96.09773;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;13;-884.5263,624.6617;Inherit;False;Property;_ColorCabello;ColorCabello;6;0;Create;True;0;0;0;False;0;False;0.4716981,0.3192614,0.1575293,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;-544.5381,461.7112;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;12;15.87709,64.04364;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;3;-958.7935,792.4174;Inherit;True;Property;_mascaracabello;mascara cabello;2;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;15;181.5414,185.6496;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;416.6954,-142.2374;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;MorionPersonalizable;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;1;0
WireConnection;5;1;4;0
WireConnection;6;0;1;0
WireConnection;6;1;5;0
WireConnection;6;2;2;1
WireConnection;8;0;1;0
WireConnection;8;1;7;0
WireConnection;9;0;6;0
WireConnection;9;1;8;0
WireConnection;9;2;2;2
WireConnection;11;0;1;0
WireConnection;11;1;10;0
WireConnection;14;0;1;0
WireConnection;14;1;13;0
WireConnection;12;0;9;0
WireConnection;12;1;11;0
WireConnection;12;2;2;3
WireConnection;15;0;12;0
WireConnection;15;1;14;0
WireConnection;15;2;3;1
WireConnection;0;0;15;0
ASEEND*/
//CHKSM=A0833922A95A443C4C11EB779E8D78F67CFE373E