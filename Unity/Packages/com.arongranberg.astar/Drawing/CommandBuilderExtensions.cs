// This file is automatically generated by a script based on the CommandBuilder API.
// This file adds additional overloads to the CommandBuilder API with convenience parameters like colors and durations.
using Unity.Burst;
using UnityEngine;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Pathfinding.Drawing {
	public partial struct CommandBuilder {
		/// <summary>\copydoc Line(float3,float3)</summary>
		public void Line (float3 a, float3 b, Color color) {
			Reserve<Color32, LineData>();
			Add(Command.Line | Command.PushColorInline);
			Add((Color32)color);
			Add(new LineData { a = a, b = b });
		}

		/// <summary>\copydoc Ray(float3,float3)</summary>
		public void Ray (float3 origin, float3 direction, Color color) {
			Line(origin, origin + direction, color);
		}

		/// <summary>\copydoc Ray(Ray,float)</summary>
		public void Ray (Ray ray, float length, Color color) {
			Line(ray.origin, ray.origin + ray.direction * length, color);
		}

		/// <summary>\copydoc CircleXZ(float3,float,float,float)</summary>
		/// <param name="color">Color of the object</param>
		public void CircleXZ (float3 center, float radius, float startAngle, float endAngle, Color color) {
			Reserve<Color32, CircleXZData>();
			Add(Command.CircleXZ | Command.PushColorInline);
			Add((Color32)color);
			Add(new CircleXZData { center = center, radius = radius, startAngle = startAngle, endAngle = endAngle });
		}

		/// <summary>\copydoc CircleXZ(float3,float,float,float)</summary>
		/// <param name="color">Color of the object</param>
		public void CircleXZ (float3 center, float radius, Color color) {
			CircleXZ(center, radius, 0f, 2 * Mathf.PI, color);
		}

		/// <summary>\copydoc WireCylinder(float3,float3,float)</summary>
		public void WireCylinder (float3 bottom, float3 top, float radius, Color color) {
			WireCylinder(bottom, top - bottom, math.length(top - bottom), radius, color);
		}

		/// <summary>\copydoc WireCylinder(float3,float3,float,float)</summary>
		public void WireCylinder (float3 position, float3 up, float height, float radius, Color color) {
			PushColor(color);
			var tangent = math.normalizesafe(math.cross(up, new float3(1, 1, 1)));

			// Note: second parameter is normalized (-1,1,1)
			if (math.all(tangent == float3.zero)) tangent = math.cross(up, new float3(-0.577350269f, 0.577350269f, 0.577350269f));

			PushMatrix(Matrix4x4.TRS(position, Quaternion.LookRotation(tangent, up), new Vector3(radius, height, radius)));
			CircleXZ(float3.zero, 1);
			if (height > 0) {
				CircleXZ(new float3(0, 1, 0), 1);
				Line(new float3(1, 0, 0), new float3(1, 1, 0));
				Line(new float3(-1, 0, 0), new float3(-1, 1, 0));
				Line(new float3(0, 0, 1), new float3(0, 1, 1));
				Line(new float3(0, 0, -1), new float3(0, 1, -1));
			}
			PopMatrix();
			PopColor();
		}

		/// <summary>\copydoc Polyline(List<Vector3>,bool)</summary>
		/// <param name="color">Color of the object</param>
		[BurstDiscard]
		public void Polyline (List<Vector3> points, bool cycle, Color color) {
			PushColor(color);
			for (int i = 0; i < points.Count - 1; i++) {
				Line(points[i], points[i+1]);
			}
			if (cycle && points.Count > 1) Line(points[points.Count - 1], points[0]);
			PopColor();
		}

		/// <summary>\copydoc Polyline(List<Vector3>,bool)</summary>
		/// <param name="color">Color of the object</param>
		[BurstDiscard]
		public void Polyline (List<Vector3> points, Color color) {
			Polyline(points, false, color);
		}

		/// <summary>\copydoc Polyline(Vector3[],bool)</summary>
		/// <param name="color">Color of the object</param>
		[BurstDiscard]
		public void Polyline (Vector3[] points, bool cycle, Color color) {
			PushColor(color);
			for (int i = 0; i < points.Length - 1; i++) {
				Line(points[i], points[i+1]);
			}
			if (cycle && points.Length > 1) Line(points[points.Length - 1], points[0]);
			PopColor();
		}

		/// <summary>\copydoc Polyline(Vector3[],bool)</summary>
		/// <param name="color">Color of the object</param>
		[BurstDiscard]
		public void Polyline (Vector3[] points, Color color) {
			Polyline(points, false, color);
		}

		/// <summary>\copydoc Polyline(float3[],bool)</summary>
		/// <param name="color">Color of the object</param>
		[BurstDiscard]
		public void Polyline (float3[] points, bool cycle, Color color) {
			PushColor(color);
			for (int i = 0; i < points.Length - 1; i++) {
				Line(points[i], points[i+1]);
			}
			if (cycle && points.Length > 1) Line(points[points.Length - 1], points[0]);
			PopColor();
		}

		/// <summary>\copydoc Polyline(float3[],bool)</summary>
		/// <param name="color">Color of the object</param>
		[BurstDiscard]
		public void Polyline (float3[] points, Color color) {
			Polyline(points, false, color);
		}

		/// <summary>\copydoc Polyline(NativeArray<float3>,bool)</summary>
		/// <param name="color">Color of the object</param>
		public void Polyline (NativeArray<float3> points, bool cycle, Color color) {
			PushColor(color);
			for (int i = 0; i < points.Length - 1; i++) {
				Line(points[i], points[i+1]);
			}
			if (cycle && points.Length > 1) Line(points[points.Length - 1], points[0]);
			PopColor();
		}

		/// <summary>\copydoc Polyline(NativeArray<float3>,bool)</summary>
		/// <param name="color">Color of the object</param>
		public void Polyline (NativeArray<float3> points, Color color) {
			Polyline(points, false, color);
		}

		/// <summary>\copydoc WireBox(float3,float3)</summary>
		/// <param name="color">Color of the object</param>
		public void WireBox (float3 center, float3 size, Color color) {
			WireBox(new Bounds(center, size), color);
		}

		/// <summary>\copydoc WireBox(float3,Quaternion,float3)</summary>
		/// <param name="color">Color of the object</param>
		public void WireBox (float3 center, Quaternion rotation, float3 size, Color color) {
			PushColor(color);
			PushMatrix(Matrix4x4.TRS(center, rotation, size));
			WireBox(new Bounds(Vector3.zero, Vector3.one));
			PopMatrix();
			PopColor();
		}

		/// <summary>\copydoc WireBox(Bounds)</summary>
		public void WireBox (Bounds bounds, Color color) {
			PushColor(color);
			var min = bounds.min;
			var max = bounds.max;

			Line(new float3(min.x, min.y, min.z), new float3(max.x, min.y, min.z));
			Line(new float3(max.x, min.y, min.z), new float3(max.x, min.y, max.z));
			Line(new float3(max.x, min.y, max.z), new float3(min.x, min.y, max.z));
			Line(new float3(min.x, min.y, max.z), new float3(min.x, min.y, min.z));

			Line(new float3(min.x, max.y, min.z), new float3(max.x, max.y, min.z));
			Line(new float3(max.x, max.y, min.z), new float3(max.x, max.y, max.z));
			Line(new float3(max.x, max.y, max.z), new float3(min.x, max.y, max.z));
			Line(new float3(min.x, max.y, max.z), new float3(min.x, max.y, min.z));

			Line(new float3(min.x, min.y, min.z), new float3(min.x, max.y, min.z));
			Line(new float3(max.x, min.y, min.z), new float3(max.x, max.y, min.z));
			Line(new float3(max.x, min.y, max.z), new float3(max.x, max.y, max.z));
			Line(new float3(min.x, min.y, max.z), new float3(min.x, max.y, max.z));
			PopColor();
		}

		/// <summary>\copydoc CrossXZ(float3,float)</summary>
		public void CrossXZ (float3 position, float size, Color color) {
			PushColor(color);
			size *= 0.5f;
			Line(position - new float3(size, 0, 0), position + new float3(size, 0, 0));
			Line(position - new float3(0, 0, size), position + new float3(0, 0, size));
			PopColor();
		}

		/// <summary>\copydoc CrossXZ(float3,float)</summary>
		public void CrossXZ (float3 position, Color color) {
			CrossXZ(position, 1, color);
		}

		/// <summary>\copydoc WireGrid(float3,Quaternion,int2,float2)</summary>
		/// <param name="color">Color of the object</param>
		public void WireGrid (float3 center, Quaternion rotation, int2 cells, float2 totalSize, Color color) {
			PushColor(color);
			cells = math.max(cells, new int2(1, 1));
			PushMatrix(Matrix4x4.TRS(center, rotation, new Vector3(totalSize.x, 0, totalSize.y)));
			int w = cells.x;
			int h = cells.y;
			for (int i = 0; i <= w; i++) Line(new float3(i/(float)w - 0.5f, 0, -0.5f), new float3(i/(float)w - 0.5f, 0, 0.5f));
			for (int i = 0; i <= h; i++) Line(new float3(-0.5f, 0, i/(float)h - 0.5f), new float3(0.5f, 0, i/(float)h - 0.5f));
			PopMatrix();
			PopColor();
		}

		/// <summary>\copydoc SolidBox(float3,float3)</summary>
		/// <param name="color">Color of the object</param>
		public void SolidBox (float3 center, float3 size, Color color) {
			Reserve<Color32, BoxData>();
			Add(Command.Box | Command.PushColorInline);
			Add((Color32)color);
			Add(new BoxData { center = center, size = size });
		}

		/// <summary>\copydoc SolidBox(Bounds)</summary>
		/// <param name="color">Color of the object</param>
		public void SolidBox (Bounds bounds, Color color) {
			SolidBox(bounds.center, bounds.size, color);
		}

		/// <summary>\copydoc SolidBox(float3,Quaternion,float3)</summary>
		/// <param name="color">Color of the object</param>
		public void SolidBox (float3 center, Quaternion rotation, float3 size, Color color) {
			PushColor(color);
			PushMatrix(Matrix4x4.TRS(center, rotation, size));
			SolidBox(float3.zero, Vector3.one);
			PopMatrix();
			PopColor();
		}
	}
}
