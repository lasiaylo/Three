using System;
using UnityEngine;
using Util.Util_Classes;

namespace Garden {
	// Will rename to Soil once I get rid of old Soil class
	public class SoilGrid {
		[SerializeField] private static readonly int GridSize = 10;
		private SoilTile[,] _grid = new SoilTile[GridSize, GridSize];

		private delegate SoilTile SoilDel(SoilTile tile, int i, int j);

		public void Water(Vector2 point, int radius) {
			SoilDel del = (tile, i, j) => {
				tile.Water(1);
				return tile;
			};
			Circle(_grid, point, radius, del);
		}

		// Can refactor out to util class
		private static void Circle(SoilTile[,] grid, Vector2 point, int radius, SoilDel del) {
			point = point.Clamp(Vector2.zero, new Vector2(GridSize, GridSize));
			int xMin = (int) Mathf.Clamp(point.x - radius, 0, GridSize);
			int xMax = (int) Mathf.Clamp(point.x + radius, 0, GridSize);
			int yMin = (int) Mathf.Clamp(point.y - radius, 0, GridSize);
			int yMax = (int) Mathf.Clamp(point.y + radius, 0, GridSize);

			for (int i = xMin; i < xMax; i++) {
				for (int j = yMin; j < yMax; j++) {
					if (Vector2.Distance(new Vector2(i, j), point) <= radius) {
						del(grid[i, j], i, j);
					}
				}
			}
		}


		private static void All(SoilTile[,] grid, SoilDel del) {
			for (int i = 0; i < GridSize; i++) {
				for (int j = 0; j < GridSize; j++) {
					del(grid[i, j], i, j);
				}
			}
		}
	}

	public class SoilTile {
		public ClampedFloat damp = new ClampedFloat(0);
		public Plant plant;

		public void OnDayEnd() {
			// Dry soil by certain amount
			// Have chance of weeds to grow
		}

		public void Sow(Plant plant) {
			plant.soil = this;
		}

		public void Water(float amount) {
			damp.Val += amount;
		}
	}
}