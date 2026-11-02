public class File
{
    public bool IsDirectory {get;}
    public int Size {get;}
    public string FileName {get;}
    public string Owner {get;}
    private readonly HashSet<File> _entries = new();
    
    public File(bool isDirectory, int size, string fileName, string owner)
    {
        IsDirectory = isDirectory;
        Size = size;
        FileName = fileName;
        Owner = owner;
        
    }
    
    public object Extract(FileAttributeType attributeName)
    {
        switch(attributeName)
        {
            case FileAttributeType.SIZE: 
            return Size;

            case FileAttributeType.FILENAME:
            return FileName;

            case FileAttributeType.OWNER:
            return Owner;
            case FileAttributeType.IS_DIRECTORY:
            return  IsDirectory;

            default:
            throw new ArgumentException("Invalid criteria type");
        }

}
    
public void AddEntry(File entry)
    {
        _entries.Add(entry);
    }

}
