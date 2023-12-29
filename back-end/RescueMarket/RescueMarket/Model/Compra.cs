namespace RescueMarket.Model
{
    public class Compra
    {
        public int  NumCompra { get; set; }
        public string FechaCompra { get; set; }
        public int Cantidad { get; set; }
        public int ID_cliente { get; set; }
        public int ID_productor { get; set; }
        public int ID_producto { get; set; }


    }
}
