using UnityEngine;

public class NormalPass : MonoBehaviour {
	[Range(0.0f, 1.0f)] public float round;
	[Range(0.0f, 2.0f)] public float amplify = 1;

	public void Awake() {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		var vertices = mesh.vertices;
		var colors = new Color[vertices.Length];
		for (var i = 0; i < vertices.Length; i++) colors[i] = new Color(round, amplify, 0);

		mesh.colors = colors;
	}

	// public void Update() {
	//     Awake();
	// }
}