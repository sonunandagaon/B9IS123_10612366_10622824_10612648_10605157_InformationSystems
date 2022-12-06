using System;
using System.Collections.Generic;

namespace MusicEquipmentStore.Models;

public partial class ProductTable
{
    public int ProductId { get; set; }

    public string? Productname { get; set; }

    public byte[]? Productimage { get; set; }
}
