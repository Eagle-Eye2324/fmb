using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;

/* ╔═══════════════════════════════════════════════════════════════════════════╗
 * ║Flight Management Bot                                                      ║
 * ╟───────────────────────────────────────────────────────────────────────────╢
 * ║Made by EagleEye/aBoredDev                                                 ║
 * ║Discord: EagleEye#6238                                                     ║
 * ║Twitch: aBoredDev                                                          ║
 * ║Youtube: aBoredDev                                                         ║
 * ╟───────────────────────────────────────────────────────────────────────────╢
 * ║Why did I decide to do this?                                               ║
 * ║Just to suffer?                                                            ║
 * ║Or maybe on a suggestion from a friend that I try re-writing my bot in C#? ║
 * ║You know who you are and what you have done to me.  At least, now you do.  ║
 * ║                                                                           ║
 * ║Also, DSharpPlus's documentation is terrible                               ║
 * ╚═══════════════════════════════════════════════════════════════════════════╝
 */

// TODO: Add comments, oh god this code is unreadable to anyone axcept me
// TODO: Maybe add a description

namespace FlightManagementBot
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            // Config file loading stuff taken from one of the DSharpPlus example bots
            // First, let's load our configuration file
            var json = "";
            using (var fs = File.OpenRead("E:\\C# Projects\\Flight Management Bot\\Flight Management Bot\\config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            // Next, let's load the values from that file
            // to our client's configuration
            var cfgjson = JsonConvert.DeserializeObject<ConfigJson>(json);

            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = cfgjson.Token, 
                TokenType = TokenType.Bot,

                AutoReconnect = true,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = cfgjson.CommandPrefix
            });

            // Load some basic commands to allow for easy testing
            commands.RegisterCommands<FMBCommands>();

            // Load the logging module
            commands.RegisterCommands<LogCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }

    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }
    }
}
