using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace SpiritMod.Items.Weapon.Gun
{
    public class Crimbine : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Crimbine";
            item.damage = 17;
            item.ranged = true;
            item.width = 58;
            item.height = 32;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 6;
            item.useSound = 11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CrimBullet");
            item.shootSpeed = 9f;
            item.useAmmo = ProjectileID.Bullet;
            item.crit = 6;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("CrimBullet");
            float spread = 20 * 0.0174f;//45 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Boomstick);
            recipe.AddIngredient(ItemID.TheUndertaker);
            recipe.AddIngredient(ItemID.PhoenixBlaster, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}