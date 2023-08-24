using Newtonsoft.Json;

namespace FsaMessageGeneratorLib
{
    public static class ConfigProvider
    {
        public static Config? GetConfig(string _path)
        {
            using (var reader = new StreamReader(_path))
            {
                return JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
            }
        }
    }
}
