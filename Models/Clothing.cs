using System;
using System.Collections.Generic;

namespace TrendyThreads.Models;

public partial class Clothing
{
    public long ClothingId { get; set; }

    public string Description { get; set; } = null!;

    public long? ClothingTypeId { get; set; }

    public long? ClothingColorId { get; set; }

    public long? ClothingSizeId { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<CartClothing> CartClothings { get; set; } = new List<CartClothing>();

    public virtual ClothingColor? ClothingColor { get; set; }

    public virtual ClothingSize? ClothingSize { get; set; }

    public virtual ClothingType? ClothingType { get; set; }
}
