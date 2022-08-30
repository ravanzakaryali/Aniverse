namespace Aniverse.Application.DTOs.Common
{
    public class PaginationQuery
    {
        private int _size;
        public int Page { get; set; }
        public int Size
        {
            get { return _size; }
            set
            {
                if (value <= 1000)
                    _size = value;
                else
                    throw new Exception("Max value 1000");
            }
        }
        public PaginationQuery()
        {

        }
        public PaginationQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
