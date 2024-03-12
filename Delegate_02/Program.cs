namespace Delegate_02;

class Program {
   static void Main(string[] args) {
      Test test = new Test(); 
      test.Run2();
   }
}

delegate R Fun<R,T>(T x, T y); // Funktionstyp (T, T) : R

class Test {
   
   #region Run1
   public void Run1() {
      // Deklaration des Delegate (typsicherer Funktionszeiger)
      Fun<int,int> f1;
      
      // Objekt-Referenzmethode Add zuweisen und aufrufe
      f1 = Add;
      Console.WriteLine($"fp->Add(5,3)= { f1(5, 3) }");
      
      // statische Referenzmethode Sub zuweisen und aufrufen
      f1 = Sub;
      Console.WriteLine($"fp->Sub(5,3)= { f1(5, 3) }");
      
      // Aufruf einer Funktion höherer Ordnung (Higher Order Function = HOF)
      // Funktion enthält in der Parameterliste ein Delegate
      Console.WriteLine($"Hof1(Add,5,3)= { Hof1(Add, 5, 3) }");
      
      // und/oder als Rückgabewert ein Delegate
      Fun<int,int>? fun = Hof2(1);
      Console.WriteLine($"Hof2(1)= { fun?.Invoke(5, 3) }");

   }
   
   int Add(int x, int y) => x + y;
   static int Sub(int a, int b) => a - b;

   int Hof1(Fun<int,int> f, int x, int y) => f(x, y);
   
   Fun<int,int>? Hof2(int value) {
      if     (value == 1) return Add;
      else if(value == 2) return Sub;
      else                return null;
   }
   #endregion
   
   #region Run2
   public void Run2() {

      Func<int,int,int> f1;
      Func<int,int,int> f2;
      
      // Objekt-Referenzmethode Add zuweisen und aufrufe
      f1 = Add;
      Console.WriteLine($"fp->Add(5,3)= { f1(5, 3) }");
      
      // statische Referenzmethode Sub zuweisen und aufrufen
      f2 = Sub;
      Console.WriteLine($"fp->Sub(5,3)= { f1(5, 3) }");

      Console.WriteLine($"f1->Add1(5,3) = {f1(5, 3)}");
      Console.WriteLine($"f2->Sub1(5,3) = {f2(5, 3)}");
      
      // Aufruf einer Funktion höherer Ordnung (Higher Order Function = HOF)
      // Funktion enthält in der Parameterliste ein Delegate
      Console.WriteLine($"Hof1b(Add,5,3)= { Hof1b(Add, 5, 3) }");
      
      // und/oder als Rückgabewert ein Delegate
      Func<int,int,int>? f3 = Hof2b(1);
      Console.WriteLine($"Hof2b(1)= { f3?.Invoke(5, 3) }");
      
   }
   
   int Hof1b(Func<int,int,int> f, int x, int y) => f(x, y);
   
   Func<int,int,int>? Hof2b(int value) {
      if     (value == 1) return Add;
      else if(value == 2) return Sub;
      else                return null;
   }
   #endregion
}
