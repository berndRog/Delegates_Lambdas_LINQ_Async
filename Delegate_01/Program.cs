namespace Delegate_01;

class Program {
   static void Main(string[] args) {
      Test test = new Test(); 
      test.Run1();
   }
}

delegate int Fun(int x, int y); // Funktionstyp (int, int): int

class Test {
   
   #region Run1
   public void Run1() {
      // Deklaration des Delegate (typsicherer Funktionszeiger)
      Fun fp;
      
      // Objekt-Referenzmethode Add zuweisen und aufrufe
      fp = Add;
      var resultAdd = fp(5, 3);
      Console.WriteLine($"fp->Add(5,3)= {resultAdd}");
      
      // statische Referenzmethode Sub zuweisen und aufrufen
      fp = Sub;
      var resultSub = fp(5, 3);     
      Console.WriteLine($"fp->Sub(5,3)= {resultSub}");
      
      // Aufruf einer Funktion höherer Ordnung (Higher Order Function = HOF)
      // Funktion enthält in der Parameterliste ein Delegate
      var result1 = Hof1(Add, 5, 3);
      Console.WriteLine($"Hof1(Add,5,3)= {result1}");
      // und/oder als Rückgabewert ein Delegate
      Fun? fun = Hof2(1);
      var result2 = fun?.Invoke(5, 3);
      Console.WriteLine($"Hof2(1)= {result2}");

   }
   
   // int Add(int x, int y) {
   //    return x + y;
   // }
   int Add(int x, int y) => x + y;

   // static int Sub(int c, int d) {
   //    return c - d;
   // }
   static int Sub(int a, int b) => a - b;
   
   // int Hof1(Fun f, int x, int y) {
   //    return f(x, y);
   // }
   int Hof1(Fun f, int x, int y) => f(x, y);
   
   Fun? Hof2(int value) {
      if(value == 1)
         return Add;
      else if(value == 2)
         return Sub;
      else
         return null;
   }
   #endregion
   
   #region Run2
   public void Run2() {

      // Anonyme Methode
      Fun Add1 = delegate(int x, int y) { return x + y; };
      Fun Sub1 = delegate(int c, int d) { return c - d; };
      
      // Lambda-Ausdruck
      Fun Add2 = (int x, int y) => { return x + y; };
      Fun Sub2 = (int c, int d) => { return c - d; };
      
      Fun Add3 = (int x, int y) => x + y;
      Fun Sub3 = (int c, int d) => c - d;

      Fun Add4 = (x, y) => x + y;
      Fun Sub4 = (c, d) => c - d;

      Console.WriteLine($"Add1(5,3) = {Add1(5, 3)}");
      Console.WriteLine($"Sub1(5,3) = {Sub1(5, 3)}");
      Console.WriteLine($"Add2(5,3) = {Add2(5, 3)}");
      Console.WriteLine($"Sub2(5,3) = {Sub2(5, 3)}");
      Console.WriteLine($"Add3(5,3) = {Add3(5, 3)}");
      Console.WriteLine($"Sub3(5,3) = {Sub3(5, 3)}");
      Console.WriteLine($"Add4(5,3) = {Add4(5, 3)}");
      Console.WriteLine($"Sub4(5,3) = {Sub4(5, 3)}");
   }
   #endregion
}
