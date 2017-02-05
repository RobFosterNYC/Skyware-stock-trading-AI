using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class TalonBlade : ModItem
    {
        int charger;
        public override void SetDefaults()
        {
            item.name = "Talon Blade";     
            item.damage = 19;            
            item.melee = true;            
            item.width = 34;              
            item.height = 40;             
            item.toolTip = "Launches a feather occasionally";  
            item.useTime = 40;           
            item.useAnimation = 40;     
            item.useStyle = 1;        
            item.knockBack = 5;      
            item.value = 10000;        
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("BoneFeatherFriendly");
            item.shootSpeed = 10f;            
            item.crit = 8;  
			item.autoReuse = true;
        }
      
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        { 
                {
                    charger++;
                    if (charger >= 5)
                    {
                        for (int I = 0; I < 1; I++)
                        {
                            Projectile.NewProjectile(position.X - 8, position.Y + 8, speedX + ((float)Main.rand.Next(-230, 230) / 100), speedY + ((float)Main.rand.Next(-230, 230) / 100), mod.ProjectileType("GiantFeather"), damage, knockBack, player.whoAmI, 0f, 0f);
                        }
                        charger = 0;
                    }
                    return true;
                }
            }
		 }
    }

