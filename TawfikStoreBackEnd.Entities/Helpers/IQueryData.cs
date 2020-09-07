namespace TawfikStoreBackEnd.Entities.Helpers
{
    public interface IQueryData
    {
        bool isSortAsc { get; set; }
        int pageNum { get; set; }
        int pageSize { get; set; }
        string searchWith { get; set; }
        string sortBy { get; set; }
    }
}