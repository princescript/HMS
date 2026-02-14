using server.DTOs.Doctor;

namespace server.DTOs
{
    public class Response<T>
    {
        public int? Code { get; set; } = null;
        public bool Sucess { get; set; } = false;
        public string Message { get; set; } = " ";
        public T Data {  get; set; }
        public int? Pagination { get; set; } = null;

   
    }
}
