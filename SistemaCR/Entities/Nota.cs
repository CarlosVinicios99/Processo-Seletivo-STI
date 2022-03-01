namespace SistemaCR.Entities
{
    class Nota
    {
        public double Pontuacao {get; set;}
        public string CodigoDoCurso {get; set;}

        public Nota()
        {

        }

        public Nota(double pontuacao, string codigoDoCurso)
        {
            Pontuacao = pontuacao;
            CodigoDoCurso = codigoDoCurso;
        }
    }
}