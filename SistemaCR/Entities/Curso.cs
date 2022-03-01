using System.Collections.Generic;

namespace SistemaCR.Entities
{
    class Curso
    {
        public string Codigo {get; private set;}
        private double _crMedio;

        public Curso()
        {
        
        }

        public Curso(string codigo)
        {
            Codigo = codigo;
        }

        private double CalcularCR(List<Aluno> alunos)
        {
            double somaDasNotas = 0;
            double somaCargaHoraria = 0;
            
            foreach(Aluno aluno in alunos)
            {
                foreach(Disciplina disciplina in aluno.Disciplinas)
                {
                    if(Codigo.Equals(disciplina.Nota.CodigoDoCurso))
                    {
                        somaDasNotas += disciplina.CargaHoraria * disciplina.Nota.Pontuacao;
                        somaCargaHoraria += disciplina.CargaHoraria;
                    }
                }
            }

            if(somaCargaHoraria == 0)
            {
                return 0;
            }

            return somaDasNotas / somaCargaHoraria;
        }
        public double GetCR(List<Aluno> alunos)
        {
            _crMedio = CalcularCR(alunos);
            return _crMedio;
        }
    }
}