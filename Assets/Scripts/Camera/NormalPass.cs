using UnityEngine;

public class NormalPass : MonoBehaviour {
    [Range(0.0f, 1.0f)] public float round;
    [Range(0.0f, 2.0f)] public float amplify = 1;

    public void Awake() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Color[] colors = new Color[vertices.Length];
        for (int i = 0; i < vertices.Length; i++) {
            colors[i] = new Color(round, amplify, 0);
        }

        mesh.colors = colors;
    }

    // public void Update() {
    //     Awake();
    // }
}