using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNI_TPeleve;

namespace HNI_TPclasse
{
    class Classe
    {

        public List<Eleve> eleves { get; private set; } = new List<Eleve>();
        public string nomClasse { get; private set; }
        public List<string> matieres { get; private set; } = new List<string>();
        
        public Classe(string n)
        {
            nomClasse = n;
        }
        private float Tronquer2(float valeur)
        {
            return (float)(Math.Truncate(valeur * 100) / 100);
        }
        public void ajouterEleve(string Prenom, string Nom)
        {
            if (eleves.Count >= 30)
            {
                throw new Exception("La classe est pleine");
                
            }
            eleves.Add(new Eleve(Prenom, Nom));
        }
        public void ajouterMatiere(string matiere)
        {
            if (matieres.Count >= 10)
                throw new Exception("Maximum 10 matières.");
            matieres.Add(matiere);
        }

        public float moyenneMatiere(int matiere)
        {
            if (eleves.Count == 0)
                return 0;

            float somme = 0;

            foreach (Eleve eleve in eleves)
            {
                somme += eleve.moyenneMatiere(matiere);
            }

            return Tronquer2(somme / eleves.Count);
        }

        public float moyenneGeneral()
        {
            if (matieres.Count == 0)
                return 0;

            float somme = 0;

            for (int i = 0; i < matieres.Count; i++)
            {
                somme += moyenneMatiere(i);
            }

            return Tronquer2(somme / matieres.Count);
        }
    }
}
