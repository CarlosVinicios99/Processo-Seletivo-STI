namespace SistemaCR.Entities
{
    class Disciplina
    {
        public string Codigo {get; private set;}
        public string AnoSemestre {get; private set;}
        public int CargaHoraria {get; private set;}
        public Nota Nota {get; set;} = new Nota();

        public Disciplina()
        {

        }

        public Disciplina(string codigo, string anoSemestre, int cargaHoraria, Nota nota)
        {
            Codigo = codigo;
            AnoSemestre = anoSemestre;
            CargaHoraria = cargaHoraria;
            Nota = nota;
        }
    }
}