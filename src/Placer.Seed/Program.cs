using System;

namespace Placer.Seed
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Hello World!");
      var context = new Db.PlacerContext();
      Class1.Data.Inject(context, true);
      DND.Data.Inject(context, false);
      Console.WriteLine("Goodbye World!");
      System.Diagnostics.Process.Start("explorer", "D:\\dbs\\Placer.db3");
    }
  }
}
