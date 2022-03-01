using System.Collections.Generic;

namespace SistemaCR.Entities
{
    class Aluno
    {
        public string Matricula {get; private set;}
        public List<Disciplina> Disciplinas {get; private set;} = new List<Disciplina>();
        private double _cr;

        public Aluno()
        {

        }

        public Aluno(string matricula)
        {
            Matricula = matricula;
        }

        public void AdicionarDisciplina(Disciplina disciplina)
        {
            Disciplinas.Add(disciplina);
        }

        public void RemoverDisciplina(Disciplina disciplina)
        {
            Disciplinas.Remove(disciplina);
        }

        private double CalcularCR()
        {
            double somaDasNotas = 0, somaDasCargasHorarias = 0;
            foreach(Disciplina disciplina in Disciplinas)
            {
                somaDasNotas += disciplina.CargaHoraria * disciplina.Nota.Pontuacao;
                somaDasCargasHorarias += disciplina.CargaHoraria;
            }

            return somaDasNotas / somaDasCargasHorarias;                    
        }

        public double GetCR()
        {
            _cr = CalcularCR();
            return _cr;
        }
    }
}