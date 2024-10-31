using Newtonsoft.Json;
using System.IO;

namespace FP_EN_Brusnikau_s24109.Classes.Miscellaneous
{
	public class UserConfig
	{
		public bool IsDatabaseSeeded { get; set; }

		public static UserConfig Load(string filePath)
		{
			if (!File.Exists(filePath))
			{
				// Return default value
				return new UserConfig { IsDatabaseSeeded = false };			}

			string json = File.ReadAllText(filePath);

			return JsonConvert.DeserializeObject<UserConfig>(json);
		}

		public void Save(string filePath)
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);

			File.WriteAllText(filePath, json);
		}
	}
}
