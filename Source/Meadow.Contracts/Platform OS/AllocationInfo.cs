namespace Meadow;

/// <summary>
/// A collection of device memory-allocation statistics
/// </summary>
public struct AllocationInfo
{
    /// <summary>
    /// This is the total size of memory allocated for use by malloc in bytes. 
    /// </summary>
    public int Arena { get; set; }
    /// <summary>
    /// This is the number of free (not in use) chunks 
    /// </summary>
    public int FreeBlocks { get; set; }
    /// <summary>
    /// Size of the largest free (not in use) chunk 
    /// </summary>
    public int LargestFreeBlock { get; set; }
    /// <summary>
    /// This is the total size of memory occupied by chunks handed out by malloc. 
    /// </summary>
    public int TotalAllocated { get; set; }
    /// <summary>
    /// This is the total size of memory occupied by free (not in use) chunks.
    /// </summary>
    public int TotalFree { get; set; }
}
