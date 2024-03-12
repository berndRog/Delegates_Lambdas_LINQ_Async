
using System.Collections;

class Test {

   static void Main(string[] args) {
      Test test = new Test();
      test.Run1();
   }
   
   void Run1() {
      
      List<int> numbers = [ 6, 9, 1, 4, 8, 3, 2, 5, 7, 10 ]; 
      
      foreach (var i in numbers.ReverseSequence()) {
         Console.Write($"{i}, ");
      }
      Console.WriteLine();      

      List<string> words = [ "Nektarine", "Grapefruit", "Apfel", "Himbeere",
         "Banane", "Erdbeere",  "Mango", "Clementine", "Limette", "Dattel", 
         "Feige", "Orange", "Ingwerfrucht", "Kirsche", "Papaya" ];
      
      List<Person> people = [
         new Person { Id = 1, Name = "Arne",  Age = 35 },
         new Person { Id = 2, Name = "Berta", Age = 85 },
         new Person { Id = 3, Name = "Cord",  Age = 52 },
         new Person { Id = 4, Name = "Dana",  Age = 18 },
         new Person { Id = 5, Name = "Eike",  Age = 25 }
      ];
      
      var evenNumbers1 = from num in numbers
         where num % 2 == 0
         orderby num
         select num;

      Console.WriteLine("\nEven numbers using query syntax");
      evenNumbers1.ToList().ForEach(Console.WriteLine);
      
      
      IEnumerable<int> evenNumbers2 = numbers
         .Where(num => num % 2 == 0)
         .OrderBy(num => num);

      Console.WriteLine("\nEven numbers using method syntax");
      evenNumbers2.ToList().ForEach(Console.WriteLine);
      
      
      List<int> numbers2 = [ 6, 9, 1, 4, 8, 3, 2, 5, 7, 10 ]; 
      
      // F I L T E R N
      // Where Extensions
      var sortedResult = numbers.Where(n => n % 2 == 0);
      
      sortedResult.ToList().ForEach(e => Console.Write($"{e} ")); 
      Console.WriteLine();
      
      // Take Extensions
      var takeResult = numbers.Take(4);
      
      takeResult.ToList().ForEach(e => Console.Write($"{e} ")); 
      Console.WriteLine();
      
      // Skip Extensions
      var skipResult = numbers.Skip(4);
      
      skipResult.ToList().ForEach(e => Console.Write($"{e} ")); 
      Console.WriteLine();
      
      // Select Extensions
      IEnumerable<int> squares = numbers.Select(n => n * n);
      squares.ToList().ForEach(e => Console.Write($"{e} "));
      Console.WriteLine();
      
      var result = people.Select(p => new { p.Name, p.Age } );
      result.ToList().ForEach(e => Console.WriteLine($"{e.Name} {e.Age}"));
      
      // alternative
      people
         .Select(p => new { p.Name, p.Age } )
         .ToList()
         .ForEach(e => Console.WriteLine($"{e.Name} {e.Age}"));
      
      
      // SelectMany Extensions
      List<List<int>> list = new List<List<int>>
      {
         new List<int> { 1, 2, 3 },
         new List<int> { 4, 5, 6 },
         new List<int> { 7, 8, 9 }
      };
      
      Console.WriteLine("\nSelectMany Extensions:");
      foreach (var sublist in list) {
         sublist.ForEach(item => Console.Write($"{item} "));
         Console.WriteLine();
      }
      
      IEnumerable<int> flatList = list.SelectMany(n => n);
      
      flatList.ToList().ForEach(e => Console.Write($"{e} "));
      Console.WriteLine();
      
      List<Pet> pets = new List<Pet> {
         new Pet { Id = 1, Name = "Bello",  PersonId = 1 },
         new Pet { Id = 2, Name = "Luna",   PersonId = 2 },
         new Pet { Id = 3, Name = "Lucky",  PersonId = 3 },
         new Pet { Id = 4, Name = "Milo",   PersonId = 1 },
      };


      var personPets = people
         .SelectMany(
            person => pets.Where(pet => pet.PersonId == person.Id),
               (person, pet) => new {
                  PersonName = person.Name, 
                  PetName = pet.Name
               }
         );
   
      personPets.ToList().ForEach(e => Console.WriteLine($"{e.PersonName} {e.PetName}"));
      
      //
      // Sorting OrderBy(Ascebding) and OrderByDescending")
      //
      Console.WriteLine("\nOrderBy");
      var sortedNumbers = numbers
         .OrderBy(n => n);
      var sortedNumbersDesc = numbers
         .OrderByDescending(n => n);
      
      sortedNumbers.ToList().ForEach(e => Console.Write($"{e} ")); 
      Console.WriteLine();
      sortedNumbersDesc.ToList().ForEach(e => Console.Write($"{e} ")); 
      Console.WriteLine();
      
      Console.WriteLine("\nOrderBy second letter");
      words
         .OrderBy(w => w[1])  // sort by second letter
         .ToList()
         .ForEach(w => Console.Write($"{w} "));
      Console.WriteLine();
      
      //
      // Grouping
      //
      // group word by second letter
      Console.WriteLine("\nGroupBy second letter and order by key");
      List<IGrouping<char, string>> grouped = 
         words
            .GroupBy(w => w[1])
            .OrderBy(w => w.Key)
            .ToList();
      
      grouped
         .ForEach(w => {
            Console.Write($"{w.Key}: ");
            w.ToList().ForEach(e => Console.Write($"{e} "));
            Console.WriteLine();
         });
      
      
      //
      // Elementoperations, FirstOrDefault / SingleOrDefault
      //
      Console.WriteLine("\nFirstOrDefault");
      var first = words.FirstOrDefault(w => w.Contains("beere"));
      first?.ToList().ForEach(e => Console.Write($"{e}"));
      Console.WriteLine();

      try {
         var single = words.SingleOrDefault(w => w.Contains("bäere"));
         single?
            .ToList()
            .ForEach(e => Console.Write($"{e}"));
         Console.WriteLine();
      } catch (Exception e) {
         Console.WriteLine(e.Message);
      }
      
      //
      // Predicates: Any / All
      //
      Console.WriteLine("\nAny, All");
      bool hasEvenNumbers = numbers.Any(n => n % 2 == 0);
      bool allEvenNumbers = numbers.All(n => n % 2 == 0);
      Console.WriteLine($"sequence has even numbers: {hasEvenNumbers}");
      Console.WriteLine($"all numbers in sequence are even: {allEvenNumbers}");

      //
      // Aggregates: Count / Sum / Average / Min / Max
      //
      Console.WriteLine("\nAggregates: Count / Sum / Average / Min / Max");
      int count = numbers.Count();
      int sum = numbers.Sum();
      double average = numbers.Average();
      int min = numbers.Min();
      int max = numbers.Max();
      
      Console.WriteLine($"count: {count}");
      Console.WriteLine($"sum: {sum}");
      Console.WriteLine($"average: {average}");
      Console.WriteLine($"min: {min}");
      Console.WriteLine($"max: {max}");
      
   }
   
   void Run2() {

      List<Person> people = [
         new Person { Name = "Arne",  Age = 35, Gender = 'm' },
         new Person { Name = "Berta", Age = 85, Gender = 'f' },
         new Person { Name = "Cord",  Age = 52, Gender = 'm' },
         new Person { Name = "Dana",  Age = 18, Gender = 'f' },
         new Person { Name = "Eike",  Age = 25, Gender = 'm' }
      ];

      var selected = people.Select(p => p.Name);
      
   }
}

class Person {
   public int    Id     { get; set; }
   public string Name   { get; set; }
   public int    Age    { get; set; }
   public char   Gender { get; set; }
}

public class Pet {
   public int Id { get; set; }
   public string Name { get; set; }
   public int PersonId { get; set; }
}

public static class EnumerableExtensions {
   
   public static IEnumerable<T> ReverseSequence<T>(
      this IEnumerable<T> source
   ) {
      
      Stack<T> stack = new Stack<T>();
      
      // push all items onto the stack
      foreach (T item in source)
         stack.Push(item);
     
      // pop them off the stack, item by item
      while (stack.Count > 0) 
         yield return stack.Pop();
      
   }
}
 

