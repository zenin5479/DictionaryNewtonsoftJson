﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DictionaryNewtonsoftJson
{
   internal class Program
   {
      static void Main()
      {
         // Десериализация словарей Newtonsoft.Json по строке
         const string json = @"{""Androids Battle"":""YoRHa No.2 Type B"",""Age"":""3""}";
         Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
         Console.WriteLine("Androids Battle = " + values["Androids Battle"] + "\n" + "Age = " + values["Age"]);
         foreach (KeyValuePair<string, string> keyvaluepair in values)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }

         // Десериализация словарей Newtonsoft.Json по классу
         MyClient element = new MyClient
         {
            Data = new StringBuilder(@"{""Androids Battle"":""YoRHa No.2 Type B"",""Age"":""3""}")
         };

         Dictionary<string, string> valueselement = JsonConvert.DeserializeObject<Dictionary<string, string>>(element.Data.ToString());
         Console.WriteLine("Androids Battle = " + valueselement["Androids Battle"] + "\n" + "Age = " + valueselement["Age"]);
         foreach (KeyValuePair<string, string> keyvaluepair in valueselement)
         {
            Console.WriteLine($"{keyvaluepair.Key} = {keyvaluepair.Value}");
         }

         // Десериализация словарей Newtonsoft.Json по строке из файла
         string jsonfile = File.ReadAllText("YoRHa2B.json");
         Dictionary<string, string> valuesjsonfile = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonfile);
         foreach (KeyValuePair<string, string> pairkeyvalue in valuesjsonfile)
         {
            Console.WriteLine($"{pairkeyvalue.Key} = {pairkeyvalue.Value}");
         }

         // Десериализация во вложенный словарь Newtonsoft.Json по строке
         // Если нет возможности создавать класс для вложенного объекта, можно десериализовать его во вложенный словарь.
         const string jsonnesteddictionary = @"{""Androids Battle"": {""Name"": ""YoRHa No.2 Type B"", ""Age"": ""3""},""Androids Scanner"": {""Name"": ""YoRHa No.9 Type S"",""Age"": ""3""}}";
         Dictionary<string, Dictionary<string, string>> nesteddictionary = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonnesteddictionary);
         foreach (KeyValuePair<string, Dictionary<string, string>> keyvaluepair in nesteddictionary)
         {
            Console.WriteLine(keyvaluepair.Key);
            foreach (KeyValuePair<string, string> pairkeyvalue in keyvaluepair.Value)
            {
               Console.WriteLine($"\t{pairkeyvalue.Key} = {pairkeyvalue.Value}");
            }
         }

         // Десериализация во вложенный словарь Newtonsoft.Json по строке из файла
         string jsonnesteddictionaryfile = File.ReadAllText("NestedDictionary.json");
         Dictionary<string, Dictionary<string, string>> nesteddictionaryfile = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonnesteddictionaryfile);
         foreach (KeyValuePair<string, Dictionary<string, string>> keyvaluepair in nesteddictionaryfile)
         {
            Console.WriteLine(keyvaluepair.Key);
            foreach (KeyValuePair<string, string> pairkeyvalue in keyvaluepair.Value)
            {
               Console.WriteLine($"\t{pairkeyvalue.Key} = {pairkeyvalue.Value}");
            }
         }

         Console.ReadKey();
      }
   }

   class MyClient
   {
      public StringBuilder Data;
   };
}