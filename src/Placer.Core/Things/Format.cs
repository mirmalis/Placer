using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Placer.Core
{
  public class Format : IDed
  {
    public string Name { get; set; }
    public int? Priority { get; set; }
    public ICollection<FormatStringPart> StringParts { get; set; }
    public ICollection<FormatPart> Parts { get; set; }
  }
}
