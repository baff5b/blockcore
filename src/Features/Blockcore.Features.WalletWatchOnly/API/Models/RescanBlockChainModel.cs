using Newtonsoft.Json;

namespace Blockcore.Features.WalletWatchOnly.Api.Models
{
    public class RescanBlockChainModel
    {
        [JsonProperty(PropertyName = "start_height")]
        public int StartHeight { get; set; }

        [JsonProperty(PropertyName = "stop_height")]
        public int StopHeight { get; set; }
    }
}