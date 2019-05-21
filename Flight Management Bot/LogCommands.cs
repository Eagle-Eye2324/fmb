using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace FlightManagementBot
{
    public class LogCommands
    {
        [Command("log")]
        public async Task Log(CommandContext ctx, int dtime, int atime, string dicao, string aicao)
        {
            // WIP - Not yet fully implemented.
            // TODO: Implement input sanitization
            // TODO: Implement a check on whether or not the ICAO codes supplied are valid

            int[] dtimedigits = dtime.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] atimedigits = dtime.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            if(dtimedigits.Length == 3)
            {

            }

            await ctx.RespondAsync($"```css\nPilot: { ctx.User.Username }\nDeparted from: { dicao }\nAt: { dtime }\nArrived in: { aicao }\nAt: { atime }\n```");
        }
    }
}