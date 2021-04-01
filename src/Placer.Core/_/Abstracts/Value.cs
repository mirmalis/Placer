using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Placer.Core
{
  [Owned]
  public class Value
  {
    public enum DataType
    {
      Unknown, Flag, Boolean, Integer, String, DateTime
    }
    public DataType Type { get; set; }
    public byte[] Data { get; set; }

    #region Helpers
    public string String
    {
      get
      {
        if (Type != DataType.String)
          return null;
        return Encoding.UTF8.GetString(Data);
      }
      set
      {
        this.Type = DataType.String;
        if (value == null)
        {
          this.Data = null;
          return;
        }
        this.Data = Encoding.UTF8.GetBytes(value);
      }
    }
    public int? Integer
    {
      get
      {
        //if (Type != DataType.Integer)
        //  return null;
        return BitConverter.ToInt32(this.Data);
      }
      set
      {
        this.Type = DataType.Integer;
        if (value == null)
        {
          this.Data = null;
          return;
        }
        this.Data = BitConverter.GetBytes(value.Value);
      }
    }
    public DateTime? DateTime
    {
      get
      {
        if (Type != DataType.DateTime)
          return null;
        return new DateTime(BitConverter.ToInt32(this.Data));
      }
      set
      {
        this.Type = DataType.DateTime;
        if (value == null)
        {
          this.Data = null;
          return;
        }
        BitConverter.GetBytes(value.Value.Ticks);
      }
    }
    public static implicit operator Value(string value) => new() { String = value };
    public static implicit operator Value(int value) => new() { Integer = value };
    public static implicit operator Value(DateTime value) => new() { DateTime = value };
    public static implicit operator Value(bool value) => new() { Integer = value ? 1 : 0, Type = DataType.Boolean };
    public override string ToString() =>
     this.Type switch
     {
       DataType.String => $"\"{String.Replace("\"", "\\\"")}\"",
       DataType.Integer => Integer.ToString(),
       DataType.Boolean => Integer.ToString(),
       DataType.DateTime => DateTime.ToString(),
       _ => Data.ToString()
     };
    #endregion
  }
}