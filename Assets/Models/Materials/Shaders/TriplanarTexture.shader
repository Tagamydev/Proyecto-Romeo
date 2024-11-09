Shader "Custom/TriplanarTexture"
{
	Properties
	{
		_MainTex("Albedo (Base Map)", 2D) = "white" {}
	_Tile("Tiling", Float) = 1
	}
		SubShader
	{
		Tags{ "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert

		sampler2D _MainTex;
	float _Tile;

	struct Input
	{
		float3 worldPos; // Posición en el mundo del fragmento
		float3 worldNormal; // Normal en el mundo
	};

	void surf(Input IN, inout SurfaceOutput o)
	{
		// Normal absoluta para determinar el eje dominante
		float3 absWorldNormal = abs(normalize(IN.worldNormal));

		// UVs para cada eje, multiplicando por el tiling deseado
		float2 uvX = IN.worldPos.zy * _Tile;
		float2 uvY = IN.worldPos.xz * _Tile;
		float2 uvZ = IN.worldPos.xy * _Tile;

		// Aplicación de la textura en cada eje
		float4 texX = tex2D(_MainTex, uvX);
		float4 texY = tex2D(_MainTex, uvY);
		float4 texZ = tex2D(_MainTex, uvZ);

		// Mezcla de las texturas basada en la orientación de la normal
		o.Albedo = (texX.rgb * absWorldNormal.x +
			texY.rgb * absWorldNormal.y +
			texZ.rgb * absWorldNormal.z) /
			(absWorldNormal.x + absWorldNormal.y + absWorldNormal.z);
	}
	ENDCG
	}
		FallBack "Diffuse"
}