using Persistence;
namespace Core;

public class CHigh {
   
 private readonly CLow _low;
  // private readonly ILow _low;
   
   public CHigh() {
      Console.WriteLine("CHigh.Ctor()");
      _low = new CLow();
   }
   
   public void Run() {
      Console.WriteLine("CHigh.Run()");
      _low.Run();
   }
   
}