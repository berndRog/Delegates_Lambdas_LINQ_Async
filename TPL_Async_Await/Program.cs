using System.Diagnostics;

class Test {
   private readonly Stopwatch stopwatch1 = new();
   private readonly Stopwatch stopwatch2 = new();
   private readonly int durationtMs = 1000;

   
// static void Main() {
   async static Task Main() {
      
      var test = new Test();
      test.Run1();
      test.Run2();
      test.Run3();
      await test.Run4Async();
      await test.Run5Async();
   }

   #region Run1 ----------------------------------------------------------------
   void Run1() {
      Console.WriteLine("--- sequential, sychrounous code ---");
      stopwatch1.Start();
      var result1 = ReadFromIO(1);
      var result2 = ReadFromIO(2);
      var result3 = ReadFromIO(3);
      Console.WriteLine($"Insgesamt {stopwatch1.ElapsedMilliseconds} ms");
   }

   int ReadFromIO(int taskNr) {
      Start(taskNr);
      
      Print(taskNr, $"Ausführung ...       ");
      Thread.Sleep(durationtMs); // wait for io operation
      var result = new Random().Next(1,10);
      
      Stop(taskNr);
      return result;
   }


   void Print(int nr, string text) =>
      Console.WriteLine(
         $"Task {nr,2} {text} Thread:{Thread.CurrentThread.ManagedThreadId}");

   void Start(int taskNr) {
      stopwatch2.Restart();
      Console.Write($"Task {taskNr,2} gestartet           - ");
      Console.WriteLine($"Thread:{Thread.CurrentThread.ManagedThreadId}");
   }

   void Stop(int taskNr) {
      Console.Write($"Task {taskNr,2} fertig   in ");
      Console.WriteLine($"{stopwatch2.ElapsedMilliseconds,4} ms -");
   }
   #endregion
   
   #region Run2 ----------------------------------------------------------------
   public void Run2(){
      Console.WriteLine("\n--- sequential, sychrounous code with TPL ---");
      stopwatch1.Restart();
      var result1 = ReadByTask(1);
      var result2 = ReadByTask(2);
      var result3 = ReadByTask(3);
      Console.WriteLine($"Insgesamt {stopwatch1.ElapsedMilliseconds} ms");
   }
   
   int ReadByTask(int taskNr) {    
      Start(taskNr);
      
      // Asychrounous, non-blocking code, Task Parallel Library (TPL)
      var task = Task<int>.Run(() => {
         Print(taskNr, $"Ausführung ...       ");
         Thread.Sleep(durationtMs); // wait for io operation
         return new Random().Next(1,10);
      });     
      // DO PARALLEL ASYNC STUFF
      // ...
      
      Print(taskNr, $"vor Wait()  {stopwatch2.ElapsedMilliseconds,4} ms -");
      // wait until operation is finished
      task.Wait();
      Stop(taskNr); 
      return task.Result;     
   }
   #endregion
   
   #region Run3 ----------------------------------------------------------------
   public void Run3(){
      Console.WriteLine("\n--- Parallel code ---");
      stopwatch1.Restart();
      var task1 = ReadReturnTask(1);
      var task2 = ReadReturnTask(2);
      var task3 = ReadReturnTask(3);
      
      // wait until all tasks are finished
      task1.Wait();
      task2.Wait();
      task3.Wait();
//    Task.WaitAll(task1, task2, task3);
      var result1 = task1.Result;
      var result2 = task2.Result;
      var result3 = task3.Result;
      Console.WriteLine($"Insgesamt {stopwatch1.ElapsedMilliseconds} ms");
   }
   
   Task<int> ReadReturnTask(int taskNr) {    
      Start(taskNr);
      // Asychrounous, non-blocking code, Task Parallel Library (TPL)
      return Task<int>.Run(() => { 
         Print(taskNr, $"Berechnung ...       ");
         Thread.Sleep(durationtMs); // wait for io operation
         return new Random().Next(1,10);
      });   
   }
   #endregion

   #region Run4 ----------------------------------------------------------------
   public async Task Run4Async(){
      Console.WriteLine("\n--- async/await code,  parallel ---");
      stopwatch1.Restart();
      
      var task1 = ReadAsync(1);
      var task2 = ReadAsync(2);
      var task3 = ReadAsync(3);
      
      // wait until all tasks are finished
      var result1 = await task1;
      var result2 = await task2;
      var result3 = await task3;
      Console.WriteLine($"Insgesamt {stopwatch1.ElapsedMilliseconds} ms");
   }
   
   async Task<int> ReadAsync(int taskNr) {    
      Start(taskNr);
      // Asychrounous, non-blocking code, Task Parallel Library (TPL)
      return await Task<int>.Run(() => { 
         Print(taskNr, $"Berechnung ...       ");
         Thread.Sleep(durationtMs); // wait for io operation
         return new Random().Next(1,10);
      });   
   }
   #endregion
   
   #region Run5 ----------------------------------------------------------------
   public async Task Run5Async(){
      Console.WriteLine("\n--- async/await code, sequential ---");
      stopwatch1.Restart();
      
      // wait until each method is finished
      var result1 = await ReadAsync(1);
      var result2 = await ReadAsync(2);
      var result3 = await ReadAsync(3);
      
      Console.WriteLine($"Insgesamt {stopwatch1.ElapsedMilliseconds} ms");
   }
   
   #endregion

}