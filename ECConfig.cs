using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace EsperClass
{
	public class ECConfigClient : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
        [DefaultValue(false)]
		[Label("Show Esper Class Tag")]
		[Tooltip("Shows Esper Class tag on items directly related to it")]
		public bool showEsperTag;
	}
}
