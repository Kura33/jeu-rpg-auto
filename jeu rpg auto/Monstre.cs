using System;
namespace jeux
{
    public class Monstre
    {
        private int pvMonstre;

        public string NomMonstre { get; private set; }

        public int PVMonstre //// passé un minuscule
        {
            get
            {
                return pvMonstre;
            }
                 set
            {
                if (pvMonstre < 0)
                    pvMonstre = 0; ;
            }
        }

        public int AttackMonstre { get; set; }

        public int MinRandom { get; protected set; }
        public int MaxRandom { get; protected set; }

        public Monstre(string nomMonstre, int minRandom, int maxRandom)
        {
            MinRandom = minRandom;
            MaxRandom = maxRandom;
            NomMonstre = nomMonstre;
            PVMonstre = random.Next(MinRandom, MaxRandom);
            AttackMonstre = random.Next(MinRandom, MaxRandom);
        }


        private static Random random = new Random();
        public static Monstre RandomMonstre()
        {
            int RandomMonstre = random.Next(1, 101);
            if (RandomMonstre >= 1 && RandomMonstre < 60)
            {
                return new Larbin();
            }
            else if (RandomMonstre >= 61 && RandomMonstre < 90)
            {
                return new Capitaine();
            }
            else return new Boss();
            
        }

        public void Tuer()
        {
            if (NomMonstre is "Boss" && PVMonstre > 10)
            {
                PVMonstre /= 2;
            }
            else

            {
                PVMonstre = 0;
            }



        }
    }
}
