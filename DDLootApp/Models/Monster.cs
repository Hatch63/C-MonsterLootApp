using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDLootApp.Models
{
    public class Monster
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<MonsterItem> MonsterItems { get; set; }
    }
}
