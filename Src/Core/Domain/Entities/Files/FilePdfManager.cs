using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites.FilePdfManagers;

public class FilePdfManager
{
  
    public Guid stream_id { get; set; }


    public byte[] file_stream { get; set; }


    public string name { get; set; }

    //[Column("path_locator")]
    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    //public byte[] PathLocator { get; set; }

    //[Column("parent_path_locator")]
    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    //public byte[] ParentPathLocator { get; set; }

 
    public string file_type { get; set; }

   
    public long? CachedFileSize { get; set; }

 
    public DateTimeOffset creation_time { get; set; }

    public DateTimeOffset last_write_time { get; set; }


    public DateTimeOffset? LastAccessTime { get; set; }

    
    public bool Isdirectory { get; set; }


    public bool Isoffline { get; set; }

  
    public bool Ishidden { get; set; }


    public bool Isreadonly { get; set; }


    public bool Isarchive { get; set; }

    public bool Issystem { get; set; }


    public bool Istemporary { get; set; }
}
