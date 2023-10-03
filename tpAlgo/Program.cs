using System;
using System.Collections.Generic;
using System.IO;
namespace ExoAlgo{
    class ExoAlgo{
        static void Main(string[] args)
        {
           System.Console.WriteLine("Begin");
           string nomFichier="liste_francais.txt";
           try{
            string[] lignes = File.ReadAllLines(nomFichier);
            List<string> mots=new List<string>(lignes);
            System.Console.WriteLine(mots[100]);//abrité
           }catch(Exception e){
            System.Console.WriteLine(e.Message);
           }
        }
    }
}