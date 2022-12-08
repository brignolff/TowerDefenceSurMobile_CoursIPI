using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
		public static class Config
		{
				public static string OpponentTag = "Opponent";

				public static string ProjectileTag = "Projectile";

				public static int Score;

				public static int StartingScore = 10;

				public static float SoundLevel = 1;

				public static int StartingSpawnInterval = 3000;

				public static int SpawnIntervalReductionPerDifficultyIncrease = 100;

				public static int DifficultyIncreaseInterval = 10000;
		}
}
