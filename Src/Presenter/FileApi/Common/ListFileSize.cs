using Domain.Enums;

namespace FileApi.Common;

public class ListFileSize
{
    public FileType FileType { get; init; }
    public int Size { get; init; }
}