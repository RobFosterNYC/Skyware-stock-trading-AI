﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Atlas
{
    public class CobbledEye : ModNPC
    {
        // npc.ai[0] = state manager.
        int timer = 0;
        bool start = true;
        public override void SetDefaults()
        {
            npc.name = "Cobbled Eye";
            npc.width = 42;
            npc.height = 42;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.damage = 30;
            npc.lifeMax = 200;

        }

        public override bool PreAI()
        {
            if (start)
            {
                for (int num621 = 0; num621 < 15; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 1, 0f, 0f, 100, default(Color), 2f);
                   
                }
                npc.ai[1] = npc.ai[0];
                start = false;
            }
            
            //Making player variable "p" set as the npc's owner
            npc.TargetClosest(true);
            Vector2 direction = Main.player[npc.target].Center - npc.Center;
            direction.Normalize();
            direction *= 7f;
            npc.rotation = direction.ToRotation();
            timer++;
            if (timer > 60)
            {
                if (Main.rand.Next(10) == 1)
                {
                    int proj2 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("MiracleBeam"), 25, 1f, npc.target);
                }
                timer = 0;
            }
            Player player = Main.player[npc.target];
            NPC parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("Atlas"))];
            //Factors for calculations
            double deg = (double)npc.ai[1]; //The degrees, you can multiply npc.ai[1] to make it orbit faster, may be choppy depending on the value
            double rad = deg * (Math.PI / 180); //Convert degrees to radians
            double dist = 200; //Distance away from the player

            /*Position the npc based on where the player is, the Sin/Cos of the angle times the /
    		/distance for the desired distance away from the player minus the npc's width   /
    		/and height divided by two so the center of the npc is at the right place.     */
            npc.position.X = parent.Center.X - (int)(Math.Cos(rad) * dist) - npc.width / 2;
            npc.position.Y = parent.Center.Y - (int)(Math.Sin(rad) * dist) - npc.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            npc.ai[1] += 2f;
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (npc.velocity != Vector2.Zero)
            {
                Texture2D texture = Main.npcTexture[npc.type];
                Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);

                for (int i = 1; i < npc.oldPos.Length; ++i)
                {
                    Vector2 vector2_2 = npc.oldPos[i];
                    Microsoft.Xna.Framework.Color color2 = Color.White * npc.Opacity;
                    color2.R = (byte)(0.5 * (double)color2.R * (double)(10 - i) / 20.0);
                    color2.G = (byte)(0.5 * (double)color2.G * (double)(10 - i) / 20.0);
                    color2.B = (byte)(0.5 * (double)color2.B * (double)(10 - i) / 20.0);
                    color2.A = (byte)(0.5 * (double)color2.A * (double)(10 - i) / 20.0);
                    Main.spriteBatch.Draw(Main.npcTexture[npc.type], new Vector2(npc.oldPos[i].X - Main.screenPosition.X + (npc.width / 2),
                        npc.oldPos[i].Y - Main.screenPosition.Y + npc.height / 2), new Rectangle?(npc.frame), color2, npc.oldRot[i], origin, npc.scale, SpriteEffects.None, 0.0f);
                }
            }
            return true;
        }
    }
}
