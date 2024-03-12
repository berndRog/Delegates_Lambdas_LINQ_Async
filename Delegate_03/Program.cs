namespace Delegate_03;

class Program {
   static void Main(string[] args) {
      Test test = new Test(); 
      test.Run2();
   }
}

class Test {
   
   #region Run1
   public void Run1() {
      
      var collection = new CollectionWithDelegates();
      
      collection.Add( (x,y) => x+y );
      collection.Add( (x,y) => x-y );
      collection.Add( (x,y) => x*y ); 
      
      collection.Invoke(5,3);
      
   }
   #endregion
   
   #region Run2
   public void Run2() {
      
      var collection = new CollectionWithDelegatesGeneric<double, double>();
      
      collection.Add( (x,y) => x+y );
      collection.Add( (x,y) => x-y );
      collection.Add( (x,y) => x*y ); 
      
      collection.Invoke(5.1, 3.333);
      
   }
   #endregion
}