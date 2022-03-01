using System;
using System.Collections.Generic;
using SistemaCR.Entities;
using SistemaCR.Repositories;

namespace SistemaCR
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> dadosDasNotas = ManipulaDados.carregarDados("./Repositories/Arquivos/notas.csv");

            List<Curso> cursos = new List<Curso>();
            List<Aluno> alunos = new List<Aluno>();

            //lendo todos os cursos
            foreach(string[] registroDeNota in dadosDasNotas)
            {
                string codigoDoCurso = registroDeNota[2];
                bool cursoExiste = cursos.Find(c => c.Codigo.Equals(codigoDoCurso)) != null;

                if(!cursoExiste)
                {
                    cursos.Add(new Curso(codigoDoCurso));
                }
            }

            //lendo todos os alunos com suas disciplinas e notas
            foreach(string[] registroDeNota in dadosDasNotas)
            {
                string matriculaDoAluno = registroDeNota[0];
                bool alunoExiste = alunos.Find(al => al.Matricula.Equals(matriculaDoAluno)) != null;

                if(!alunoExiste)
                {
                    alunos.Add(new Aluno(matriculaDoAluno));
                }

               Nota nota = new Nota(double.Parse(registroDeNota[3]), registroDeNota[2]);

                Disciplina disciplina = new Disciplina(registroDeNota[1], registroDeNota[5], int.Parse(registroDeNota[4]), nota);

                Aluno aluno_aux = alunos.Find(al => al.Matricula.Equals(registroDeNota[0]));
                
                if(aluno_aux != null)
                {
                    aluno_aux.Disciplinas.Add(disciplina);
                }
            }

            Console.WriteLine("-------- CR dos alunos --------");
            foreach(Aluno aluno in alunos)
            {
                Console.WriteLine($"{aluno.Matricula} => {aluno.GetCR().ToString("F1")}");
            }

            Console.WriteLine();
            Console.WriteLine("-------- CR dos cursos --------");
            foreach(Curso curso in cursos)
            {
                Console.WriteLine($"{curso.Codigo} => {curso.GetCR(alunos).ToString("F1")}");
            }

        }
    }
}
