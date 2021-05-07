namespace Easy_Stock.Entidades
{
    public class TipoCliente
    {
        public int idTipoCliente { get; set; } = 0;
        public string tipoCliente { get; set; } = string.Empty;

        public TipoCliente()
        {
            this.idTipoCliente = 0;
            this.tipoCliente = string.Empty;
        }
    }
}