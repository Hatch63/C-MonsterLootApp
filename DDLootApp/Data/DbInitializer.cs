using DDLootApp.Models;
using System;
using System.Linq;

namespace DDLootApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LootContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any Monsters.
            if (context.Monster.Any())
            {
                return;   // DB has been seeded
            }

            var monsters = new Monster[]
            {
            new Monster{Name="Beholder"},
            new Monster{Name="Ancient Red Dragon"},
            new Monster{Name="Goblin"},
            new Monster{Name="Lich"},
            new Monster{Name="Frost Giant"},
            new Monster{Name="Fire Newt"},
            new Monster{Name="Medusa"},
            new Monster{Name="Bugbear"}
            };
            foreach (Monster s in monsters)
            {
                context.Monster.Add(s);
            }
            context.SaveChanges();

            var monsterItems = new MonsterItem[]
            {
            new MonsterItem{MonsterID=1, ItemName="A Longsword",ItemDescription="A finely made longsword", ItemRarity=ItemRarity.Common,ItemPrice=10 },
            new MonsterItem{MonsterID=2, ItemName="Red Scales",ItemDescription="Beautiful red scales", ItemRarity=ItemRarity.Uncommon,ItemPrice=100 },
            new MonsterItem{MonsterID=3, ItemName="A Club",ItemDescription="A club made out of a broken tree branch", ItemRarity=ItemRarity.Common,ItemPrice=10 },
            new MonsterItem{MonsterID=4, ItemName="Spell Book",ItemDescription="A book filled with spells", ItemRarity=ItemRarity.Rare,ItemPrice=1000 },
            new MonsterItem{MonsterID=5, ItemName="A Great Axe",ItemDescription="A giant sized great axe", ItemRarity=ItemRarity.Common,ItemPrice=10 },
            new MonsterItem{MonsterID=6, ItemName="Mushrooms",ItemDescription="A bag full of mushrooms", ItemRarity=ItemRarity.Common,ItemPrice=1 },
            new MonsterItem{MonsterID=7, ItemName="Small Statue",ItemDescription="A small statue", ItemRarity=ItemRarity.Uncommon,ItemPrice=50 },
            new MonsterItem{MonsterID=1, ItemName="Magic Wand",ItemDescription="A small wooden wand", ItemRarity=ItemRarity.Rare,ItemPrice=300 },
            new MonsterItem{MonsterID=2, ItemName="Gold Necklace",ItemDescription="A exotic gold necklace", ItemRarity=ItemRarity.Uncommon,ItemPrice=450 },
            new MonsterItem{MonsterID=3, ItemName="Talisman",ItemDescription="A crudely made talisman", ItemRarity=ItemRarity.Common,ItemPrice=10 },
            new MonsterItem{MonsterID=4, ItemName="A Ring",ItemDescription="A ring with a black stone", ItemRarity=ItemRarity.Rare,ItemPrice=350 },
            new MonsterItem{MonsterID=5, ItemName="Bag of Pelts",ItemDescription="A bag filled with animal pelts", ItemRarity=ItemRarity.Common,ItemPrice=100 },
            };
            foreach (MonsterItem e in monsterItems)
            {
                context.MonsterItems.Add(e);
            }
            context.SaveChanges();
        }

    }
}
