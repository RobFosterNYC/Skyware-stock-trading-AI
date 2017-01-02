using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class ClatterboneAxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Clatterbone Axe";
            item.width = 38;
            item.height = 30;
            item.value = 100;
            item.rare = 1;
            item.axe = 10;
            item.damage = 10;
            item.knockBack = 4;
            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 20;
            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"HardenedCarapace", 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}