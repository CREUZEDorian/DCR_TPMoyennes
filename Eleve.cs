using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNI_TPmoyennes;

namespace HNI_TPeleve
{
    
    class Eleve
    {
        public string prenom { get; private set; }
        public string nom { get; private set; }

        private List<Note> notes = new List<Note>();

        public float moyenne { get; private set; }
        public Eleve(string Prenom, string Nom)
        {
            prenom = Prenom;
            nom = Nom;
        }
        private float Tronquer2(float valeur)
        {
            return (float)(Math.Truncate(valeur * 100) / 100);
        }
        public void ajouterNote(Note note)
        {
            if (notes.Count >= 200)
                throw new Exception("Maximum 200 notes par élève.");
            notes.Add(note);
        }

        public float moyenneMatiere(int matiere)
        {
            // Calculer la moyenne de l'élève dans une matière donnée
            var notesMatiere = notes.Where(n => n.matiere == matiere).Select(n => n.note);
            if (!notesMatiere.Any())
            {
                return 0;
            }
            else
            {
                return Tronquer2((float)notesMatiere.Average());
            }
        }

        public float moyenneGeneral()
        {
            var matieres = notes
                .Select(n => n.matiere)
                .Distinct();

            if (!matieres.Any())
                return 0;

            float somme = 0;
            int nbMatieres = 0;

            foreach (int matiere in matieres)
            {
                somme += moyenneMatiere(matiere);
                nbMatieres++;
            }

            return Tronquer2(somme / nbMatieres);
        }
    }
}
