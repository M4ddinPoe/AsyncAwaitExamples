using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncThreads
{
  class Program
  {
    static void Main(string[] args)
    {
      var asyncWait = new AsyncWait();
      asyncWait.Main().GetAwaiter();

      Console.ReadLine();
    }
  }
}
