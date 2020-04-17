using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EsperClass.Projectiles.Hardmode.NonTK
{
    public class CrystalFlail : ModProjectile //Adapted from ExampleFlail by Domlight, touched up by TheLoneGamer
    {
		private const string ChainTexturePath = "EsperClass/Projectiles/Hardmode/NonTK/CrystalFlailChain";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Flail Ball");
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.localNPCHitCooldown = 10;
			projectile.usesLocalNPCImmunity = true;
		}

		public override void AI()
		{
			var player = Main.player[projectile.owner];

			if (player.dead)
			{
				projectile.Kill();
				return;
			}

			player.itemAnimation = 10;
			player.itemTime = 10;

			int newDirection = projectile.Center.X > player.Center.X ? 1 : -1;
			player.ChangeDir(newDirection);
			projectile.direction = newDirection;

			var vectorToPlayer = player.MountedCenter - projectile.Center;
			float currentChainLength = vectorToPlayer.Length();

			if (projectile.ai[0] == 0f)
			{
				float maxChainLength = 160f;
				projectile.tileCollide = true;

				if (currentChainLength > maxChainLength)
				{
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
				}
				else if (!player.channel)
				{
					if (projectile.velocity.Y < 0f)
						projectile.velocity.Y *= 0.9f;

					projectile.velocity.Y += 1f;
					projectile.velocity.X *= 0.9f;
				}
			}
			else if (projectile.ai[0] == 1f)
			{
				float elasticFactorA = 14f / player.meleeSpeed;
				float elasticFactorB = 0.9f / player.meleeSpeed;
				float maxStretchLength = 300f;

				if (projectile.ai[1] == 1f)
					projectile.tileCollide = false;

				if (!player.channel || currentChainLength > maxStretchLength || !projectile.tileCollide)
				{
					projectile.ai[1] = 1f;

					if (projectile.tileCollide)
						projectile.netUpdate = true;

					projectile.tileCollide = false;

					if (currentChainLength < 20f)
						projectile.Kill();
				}

				if (!projectile.tileCollide)
					elasticFactorB *= 2f;

				int restingChainLength = 60;

				if (currentChainLength > restingChainLength || !projectile.tileCollide)
				{
					var elasticAcceleration = vectorToPlayer * elasticFactorA / currentChainLength - projectile.velocity;
					elasticAcceleration *= elasticFactorB / elasticAcceleration.Length();
					projectile.velocity *= 0.98f;
					projectile.velocity += elasticAcceleration;
				}
				else
				{
					if (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f)
					{
						projectile.velocity.X *= 0.96f;
						projectile.velocity.Y += 0.2f;
					}
					if (player.velocity.X == 0f)
						projectile.velocity.X *= 0.96f;
				}
			}

			projectile.rotation = vectorToPlayer.ToRotation() - projectile.velocity.X * 0.1f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			bool shouldMakeSound = false;

			if (oldVelocity.X != projectile.velocity.X)
			{
				if (Math.Abs(oldVelocity.X) > 4f)
				{
					shouldMakeSound = true;
				}

				projectile.position.X += projectile.velocity.X;
				projectile.velocity.X = -oldVelocity.X * 0.2f;
			}

			if (oldVelocity.Y != projectile.velocity.Y)
			{
				if (Math.Abs(oldVelocity.Y) > 4f)
				{
					shouldMakeSound = true;
				}

				projectile.position.Y += projectile.velocity.Y;
				projectile.velocity.Y = -oldVelocity.Y * 0.2f;
			}

			projectile.ai[0] = 1f;

			if (shouldMakeSound)
			{
				projectile.netUpdate = true;
				Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			}

			return false;
		}

		public override bool PreDraw(SpriteBatch SpriteBatch, Color lightColor)
		{
			var player = Main.player[projectile.owner];

			Vector2 mountedCenter = player.MountedCenter;
			Texture2D chainTexture = ModContent.GetTexture(ChainTexturePath);

			var drawPosition = projectile.Center;
			var remainingVectorToPlayer = mountedCenter - drawPosition;

			float rotation = remainingVectorToPlayer.ToRotation() - MathHelper.PiOver2;

			if (projectile.alpha == 0)
			{
				int direction = -1;

				if (projectile.Center.X < mountedCenter.X)
					direction = 1;

				player.itemRotation = (float)Math.Atan2(remainingVectorToPlayer.Y * direction, remainingVectorToPlayer.X * direction);
			}

			while (true)
			{
				float length = remainingVectorToPlayer.Length();

				if (length < 25f || float.IsNaN(length))
					break;

				drawPosition += remainingVectorToPlayer * 12 / length;
				remainingVectorToPlayer = mountedCenter - drawPosition;

				Color color = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
				SpriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
			}

			return true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
			for (int i = 0; i < 5; i++)
			{
				int num695 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 68);
				Main.dust[num695].noGravity = true;
				Dust dust24 = Main.dust[num695];
				dust24.velocity *= 1.5f;
				Main.dust[num695].scale *= 0.9f;
			}
			if (Main.myPlayer == projectile.owner)
			{
				for (int j = 0; j < 3; j++)
				{
					float num697 = (0f - projectile.velocity.X) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
					float num696 = (0f - projectile.velocity.Y) * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
					int crystalShards = Projectile.NewProjectile(projectile.Center.X + (float)Main.rand.Next(-20, 21), projectile.Center.Y + (float)Main.rand.Next(-20, 21), num697, num696, ProjectileID.CrystalShard, (int)((double)damage * 0.5), 0f, Main.myPlayer);
					Main.projectile[crystalShards].ranged = false;
					Main.projectile[crystalShards].melee = true;
				}
			}
			base.OnHitNPC(target, damage, knockback, crit);
		}
	}
}
