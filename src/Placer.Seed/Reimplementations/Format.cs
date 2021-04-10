using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placer.Seed.Reimplementations
{
  class Format : Core.Format
  {
    #region Constructors
    public Format() { }
    public Format(string name, int? priority = null) : base()
    {
      this.Name = name;
      this.Priority = priority;
    }
    #endregion
    public int Now { get; set; }
    public Format Add(string text)
    {
      this.StringParts ??= new List<Core.FormatStringPart>();
      this.StringParts.Add(new Core.FormatStringPart() { Value = text, Order = Now++ });
      return this;
    }
    public Format Add(Core.FieldDefinition fieldDefinition)
    {
      this.Parts ??= new List<Core.FormatPart>();
      this.Parts.Add(new Core.FormatPart() { Order = Now++, FieldDefinition = fieldDefinition });
      return this;
    }
  }
}
