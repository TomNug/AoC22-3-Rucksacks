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
    
    foreach (string rucksack in lines){
      HashSet<char> rucksackSetL = new HashSet<char>();
      HashSet<char> rucksackSetR = new HashSet<char>();
      int len = rucksack.Length;
      for (int i=0; i<len/2; i++) {
        rucksackSetL.Add(rucksack[i]);
      }
      for (int i=len/2; i<len; i++) {
        rucksackSetR.Add(rucksack[i]);
      }

      rucksackSetL.IntersectWith(rucksackSetR);
      foreach(char item in rucksackSetL) {
        overlappingItems.Add(item);
      }
    }

    int score = 0;
    foreach(char overlap in overlappingItems) {
      score += scoreLetter(overlap);
      //Console.WriteLine("{0} scores {1}", overlap, scoreLetter(overlap));
    }
    Console.WriteLine(score);
    
    // Keep the console window open in debug mode.
    System.Console.ReadKey();
  }
  
}