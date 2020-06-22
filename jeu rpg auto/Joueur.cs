using System;
namespace jeux
{
    public class Joueur
    {
        private int pvJoueur;
        public string NomJoueur { get; private set; }

        public int AttackJoueur { get; set; }

        Random random = new Random();

        public int PVJoueur
        {
            get {
                return pvJoueur;
            }
            set {
                pvJoueur = value;
                if (PVJoueur > 100)
                    PVJoueur = 100;
                if (PVJoueur < 0)
                    PVJoueur = 0;
            }
            

        }

        public int Experience { get; set; }


        public Joueur (string nomJoueur)
        {
            NomJoueur = nomJoueur;
            PVJoueur = 100;
            AttackJoueur = 25;
        }

        public void PrendrePotion ()
        {
            PVJoueur += TirageSoin();
            Console.WriteLine($"{NomJoueur}, vous trouvez une Potion. Votre vie remonte à {PVJoueur} PV. ");
            System.Threading.Thread.Sleep(1000);
        }

        public void Combattre (Monstre monstre)
        {
            int xpGagne = monstre.PVMonstre;

            do
            {
                int tirageCombat = random.Next(1, 7);
                if (tirageCombat == 1)
                    PVJoueur -= monstre.AttackMonstre;
                else if (tirageCombat == 6)
                    monstre.Tuer();
                else
                {
                    PVJoueur -= monstre.AttackMonstre / 2;
                    monstre.PVMonstre -= AttackJoueur;
                }
            } while (PVJoueur > 0 && monstre.PVMonstre > 0);

            if (pvJoueur >0)
            {
                Experience += xpGagne;
            };
            Console.WriteLine($"{NomJoueur}, vous combattez {monstre.NomMonstre}. Aprés un rude combat, vous le battez. Vous en ressortez avec {PVJoueur} PV. Vous gagnez {monstre.PVMonstre} XP.");
            System.Threading.Thread.Sleep(1000);
        }

        public void Avancer()
        {
            Console.WriteLine($"{NomJoueur} avancez prudemment dans le labyrinthe. ");
            System.Threading.Thread.Sleep(1000);
        }
        

        public int TirageSoin()
        {
            int tirageSoin = random.Next(20, 41);
            return tirageSoin;
        }
        public int TirageJoueur()
        {
            int tirageJoueur = random.Next(10, 31);
            return tirageJoueur;
        }

    }

}
