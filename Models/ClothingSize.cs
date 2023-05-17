using System;
using System.Collections.Generic;

namespace TrendyThreads.Models;

public partial class ClothingSize
{
    public long ClothingSizeId { get; set; }

    public string Size { get; set; } = null!;

    public virtual ICollection<Clothing> Clothings { get; set; } = new List<Clothing>();
}
