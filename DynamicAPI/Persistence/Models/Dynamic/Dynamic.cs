using DynamicAPI.Persitence.Models.Request;

namespace DynamicAPI.Persitence.Models.Dynamic;

public class Dynamic
{
    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }
    public PageRequest? PageRequest { get; set; }

    public Dynamic()
    {
    }

    public Dynamic(IEnumerable<Sort>? sort, Filter? filter, PageRequest? pageRequest)
    {
        Sort = sort;
        Filter = filter;
        PageRequest = pageRequest;
    }
}
