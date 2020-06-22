using System;

namespace jeux
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le Labyrinthe ");

            Joueur joueur;
            joueur = new Joueur("Kura");

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"{joueur.NomJoueur}, tu dispose de {joueur.PVJoueur} PV. Est tu pret?");


            while (joueur.PVJoueur > 0)
            {
                int tirageChemin = TirageChemin();

                if (tirageChemin == 1|| tirageChemin == 2 || tirageChemin == 3)
                {
                    Monstre newMonstre = Monstre.RandomMonstre();//////////
                    joueur.Combattre(newMonstre);
                }
                else if (tirageChemin == 4)
                {
               
                    joueur.Avancer();
                }
                else
                {
                    
                    joueur.PrendrePotion();
                }
            }
            Console.WriteLine($"{joueur.NomJoueur}, vous avez {joueur.PVJoueur} PV. Vous etes mort. Vous aviez cumulé {joueur.Experience}");

        }

        public static int TirageChemin()
        {
            Random random = new Random();
            int tirageChemin = random.Next(1, 7);
            return tirageChemin;
        }

    }
}
