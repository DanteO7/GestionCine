using GestionCine.Enums;

namespace GestionCine.Modelos
{
    public class Asiento
    {
        private char _letra;
        private int _numero;
        private TipoAsiento _tipo;
        private bool _ocupado;
        public char Letra => _letra;
        public int Numero => _numero;
        public TipoAsiento Tipo => _tipo;
        public bool Ocupado => _ocupado;
        public Asiento(char letra, int numero, TipoAsiento tipo, bool ocupado)
        {
            _letra = letra;
            _numero = numero;
            _tipo = tipo;
            _ocupado = ocupado;
        }
        public void CambiarOcupado()
        {
            _ocupado = !_ocupado;
        }
    }
}
