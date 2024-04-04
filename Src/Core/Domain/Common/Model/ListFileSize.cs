using Domain.Enums;

namespace Domain.Common.Model;

public class ListFileSize
{
    public FileType FileType { get; init; }
    public int Size { get; init; }
}