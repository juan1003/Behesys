using System;

namespace Behesys.ApiService.Models
{
  public class Patient
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Gender { get; set; } = string.Empty;
    public DateTime LastVisit { get; set; }
    public string Status { get; set; } = "Active";
  }
}
