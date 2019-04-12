using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDLootApp.Models
{
    public enum ItemRarity
    {
        Common, Uncommon, Rare, SuperRare, Legendary
    }

    public class MonsterItem
    {
        public int ID { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        [Required]
        public int ItemPrice { get; set; }
        [Required]
        public int MonsterID { get; set; }
        [Required]
        public ItemRarity? ItemRarity { get; set; }

        public Monster Monster { get; set; }

    }
}
