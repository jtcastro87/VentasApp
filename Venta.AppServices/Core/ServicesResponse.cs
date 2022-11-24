
namespace Venta.AppServices.Core
{
    public class ServicesResponse
    {        

        public ServicesResponse()
        {
            this.Success = true;
        }

        public bool Success { get; set; }

        public dynamic Data { get; set; }

        public string Mensaje { get; set; }
    }
}
