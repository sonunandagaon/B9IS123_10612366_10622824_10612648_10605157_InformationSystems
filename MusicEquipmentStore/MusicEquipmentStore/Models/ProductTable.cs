using System;
using System.Collections.Generic;

namespace MusicEquipmentStore.Models;

public partial class ProductTable
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Image { get; set; }
    public string? Rating { get; set; }
    public string? Price { get; set; }
}
