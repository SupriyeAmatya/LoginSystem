namespace Login.Utils;

public class PaginatedResponse<T> : Dictionary<string, object>
{
    public PaginatedResponse(int totalPages, string valueName, IEnumerable<T> value)
    {
        this.Add("totalPages", totalPages);
        this.Add(valueName, value);
    }
}
