#ifndef CUSTOM_LIGHTING_INCLUED
#define CUSTOM_LIGHTING_INCLUED

void CalculateMainLight_float(float3 WorldPos, out float3 Direction, out float3 Color) [
#if SHADERGRAPH_PREVIEW
	Direction = float3(0.5, 0.5, 0);
	color = 1;
#else
	Light mainlight = GetMainLight(0);
	Direction = mainlight.direction;
	Color = mainlight.color;
#endif
]

#endif