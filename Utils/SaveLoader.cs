using MakeJsonFile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeJsonFile.Utils
{
    class SaveLoader
    {
        /// <summary>
		/// データの保存
		/// </summary>
		/// <param name="model"></param>
		public static void Save(RootModel model,string filepath)
        {
            File.WriteAllText(filepath, JsonConvert.SerializeObject(model, Formatting.Indented));
        }

        /// <summary>
        /// データのロード
        /// </summary>
        /// <returns></returns>
        public static RootModel.Stations[] OriginalLoad(string filepath)
        {
            return JsonConvert.DeserializeObject<RootModel.Stations[]>(File.ReadAllText(filepath));
        }

        public static RootModel Load(string filepath)
        {
            return JsonConvert.DeserializeObject<RootModel>(File.ReadAllText(filepath));
        }
    }
}
