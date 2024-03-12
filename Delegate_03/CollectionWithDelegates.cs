namespace Delegate_03;

public class CollectionWithDelegates {
   
   private List<Func<int,int,int>> _functions = new ();
   
   public void Add(Func<int,int,int> f) {
      _functions.Add(f);
   }
   
   public void Invoke(int x, int y) {
      foreach(var f in _functions) {
         var result = f(x, y);
         Console.WriteLine($"f({x},{y}) = { result}");
      }
   }
}

public class CollectionWithDelegatesGeneric<T,R> {
   
   private List<Func<T,T,R>> _functions = new ();
   
   public void Add(Func<T,T,R> f) {
      _functions.Add(f);
   }
   
   public void Invoke(T x, T y) {
      foreach(var f in _functions) {
         R result = f(x, y);
         Console.WriteLine($"f({x},{y}) = { result}");
      }
   }
}