using System.Collections.Generic;
using CommandSystem;
using PlayerStatsSystem;

namespace RemoteAdmin
{
	public static class CommandProcessor
	{
		private const int MaxStaffChatMessageLength = 2000;

		public static readonly RemoteAdminCommandHandler RemoteAdminCommandHandler;

		internal static void ProcessAdminChat(string q, CommandSender sender)
		{
		}

		internal static string ProcessQuery(string q, CommandSender sender)
		{
			return null;
		}

		internal static float GetRoundedStat<T>(ReferenceHub hub) where T : StatBase
		{
			return 0f;
		}

		internal static List<ICommand> GetAllCommands()
		{
			return null;
		}

		private static bool CheckPermissions(CommandSender sender, string queryZero, PlayerPermissions perm, string replyScreen = "", bool reply = true)
		{
			return false;
		}

		internal static bool CheckPermissions(CommandSender sender, PlayerPermissions perm)
		{
			return false;
		}
	}
}
