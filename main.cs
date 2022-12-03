using System;
using System.Collections.Generic;

class Program {
  public static int scoreLetter(char input) {
    if ((int)input > 91) {
      return (int)input - 96;
    } else {
      return (int)input - 38;
    }  
  }


    
  public static void Main (string[] args) {
    string[] lines = System.IO.File.ReadAllLines(@"rucksacks.txt");

    List<char> overlappingItems = new List<char>();
    int score = 0;
    
    for(int i=0; i<lines.Length; i+=3) {
      HashSet<char> rucksackSet1 = new HashSet<char>();
      HashSet<char> rucksackSet2 = new HashSet<char>();
      HashSet<char> rucksackSet3 = new HashSet<char>();
      foreach (char item in lines[i]){
        rucksackSet1.Add(item);
      }
      foreach (char item in lines[i+1]){
        rucksackSet2.Add(item);
      }
      foreach (char item in lines[i+2]){
        rucksackSet3.Add(item);
      }

      rucksackSet1.IntersectWith(rucksackSet2);
      rucksackSet1.IntersectWith(rucksackSet3);

      foreach(char c in rucksackSet1) {
        score += scoreLetter(c);
      }
    }
    Console.WriteLine(score);
    
    // Keep the console window open in debug mode.
    System.Console.ReadKey();
  }
  
}