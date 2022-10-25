using System;
namespace Models;

public class Pagination
{
    public bool IsPaginable { get; set; }
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
}

public class PaginationResponse
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}

