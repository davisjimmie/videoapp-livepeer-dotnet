using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LivepeerTest.Infrastructure.Services.Livepeer
{
    public class LivepeerStartStream
    {
        private readonly LivepeerClient _livepeerClient;

        public LivepeerStartStream(LivepeerClient livepeerClient)
        {
            _livepeerClient = livepeerClient;
        }

        public async Task<List<string>> StartLiveStreamAsync()
        {
            var payload =

                new
                {
                    name = "Monday Stream 7.0",
                    profiles = new[]
                {
                    new
                    {   name = "1080p",
                        bitrate = 5000000,
                        fps = 30,
                        width = 1920,
                        height = 1080
                    }
                }
                };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            var response = await _livepeerClient.Client.PostAsync("/api/stream", content);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            var streamResponse = JsonSerializer.Deserialize<StreamResponse>(responseBody);
            string streamKey = streamResponse.streamKey;
            string liveUrl = ($"https://lvpr.tv?v={streamResponse.playbackId}&lowlatency=true");

            List<string> Settings = new List<string>();
            Settings.Add(liveUrl);
            Settings.Add(streamKey);
            Console.WriteLine(streamKey);
            Console.WriteLine(liveUrl);

            return Settings;
        }
    }
}
