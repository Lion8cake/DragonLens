using DragonLens.Core.Systems.ToolSystem;
using System.IO;
using Terraria.ID;

namespace DragonLens.Content.Tools.Despawners
{
	internal class ItemDespawner : Tool
	{
		public override string IconKey => "ItemDespawner";

		public override bool SyncOnClientJoint => false;

		public override void OnActivate()
		{
			foreach (WorldItem item in Main.item)
			{
				item.type = 0;
			}

			NetSend();
		}

		public override void RecievePacket(BinaryReader reader, int sender)
		{
			foreach (WorldItem item in Main.item)
			{
				item.type = 0;
			}

			if (Main.netMode == NetmodeID.Server)
				NetSend(-1, sender);
		}
	}
}