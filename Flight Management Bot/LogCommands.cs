using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace FlightManagementBot
{
    public class LogCommands
    {
        [Command("log")]
        public async Task Log(CommandContext ctx, int dtime, int atime, string dicao, string aicao)
        {
            // WIP - Not yet fully implemented.
            // TODO: Implement input sanitization for times
            // TODO: Implement a check on whether or not the ICAO codes supplied are valid
            bool good = true;

            int[] dtimedigits = dtime.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            int[] atimedigits = dtime.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            // Sanitize departure time
            if(dtimedigits.Length == 3)
            {
                if((dtimedigits[0] < 10 && dtimedigits[0] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
                if ((dtimedigits[1] < 10 && dtimedigits[1] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
                if ((dtimedigits[2] < 6 && dtimedigits[2] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
                if ((dtimedigits[3] < 10 && dtimedigits[3] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
            }
            else if(dtimedigits.Length == 4)
            {
                if((dtimedigits[0] < 3 && dtimedigits[0] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
                if((dtimedigits[1] < 10 && dtimedigits[1] >= 0 && dtimedigits[0] < 2 && dtimedigits[0] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
                if((dtimedigits[1] < 4 && dtimedigits[1] >= 0) != true)
                {
                    if(dtimedigits[0] == 2)
                    {
                        good = false;
                        await ctx.RespondAsync(":x: Invalid departure time!");
                    }
                }
                if((dtimedigits[2] < 6 && dtimedigits[2] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
                if((dtimedigits[3] < 10 && dtimedigits[3] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid departure time!");
                }
            }
            else
            {
                good = false;
                await ctx.RespondAsync(":x: Invalid departure time!");
            }

            // Sanitize arrival time
            if (atimedigits.Length == 3)
            {
                if ((atimedigits[0] < 10 && atimedigits[0] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
                if ((atimedigits[1] < 10 && atimedigits[1] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
                if ((atimedigits[2] < 6 && atimedigits[2] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
                if ((atimedigits[3] < 10 && atimedigits[3] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
            }
            else if (atimedigits.Length == 4)
            {
                if ((atimedigits[0] < 3 && atimedigits[0] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
                if ((atimedigits[1] < 10 && atimedigits[1] >= 0 && atimedigits[0] < 2 && atimedigits[0] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
                if ((atimedigits[1] < 4 && atimedigits[1] >= 0) != true)
                {
                    if (atimedigits[0] == 2)
                    {
                        good = false;
                        await ctx.RespondAsync(":x: Invalid departure time!");
                    }
                }
                    if ((atimedigits[2] < 6 && atimedigits[2] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
                if ((atimedigits[3] < 10 && atimedigits[3] >= 0) != true)
                {
                    good = false;
                    await ctx.RespondAsync(":x: Invalid arrival time!");
                }
            }
            else
            {
                good = false;
                await ctx.RespondAsync(":x: Invalid arrival time!");
            }

            // If everything is good, then log the flight
            if (good)
            {
                DisccordEmbedBuilder embedbuilder = DiscordEmbedBuilder();
                embedbuilder.EmbedAuthor.Name = ctx.User.Mention;

                await ctx.RespondAsync($"```css\nPilot: { ctx.User.Username }\nDeparted from: { dicao }\nAt: { dtime }\nArrived in: { aicao }\nAt: { atime }\n```");
            }
        }
    }
}