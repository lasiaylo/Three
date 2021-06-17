using UnityEngine;

public class RenderReplacementShaderToTexture : MonoBehaviour {
	[SerializeField] private RenderTextureFormat renderTextureFormat = RenderTextureFormat.ARGB32;

	[SerializeField] private FilterMode filterMode = FilterMode.Point;

	[SerializeField] private int renderTextureDepth = 24;

	[SerializeField] private Color background = Color.black;

	[SerializeField] private string targetTexture = "_RenderTexture";

	private RenderTexture _renderTexture;

	private void OnEnable() {
		var _camera = GetComponent<Camera>();
		// Create a render texture matching the main camera's current dimensions.
		_renderTexture = new RenderTexture(_camera.pixelWidth, _camera.pixelHeight, renderTextureDepth,
			renderTextureFormat);
		_renderTexture.filterMode = filterMode;
		// Surface the render texture as a global variable, available to all shaders.
		Shader.SetGlobalTexture(targetTexture, _renderTexture);
		_camera.targetTexture = _renderTexture;
	}
}