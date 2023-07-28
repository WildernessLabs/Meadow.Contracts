using System.Collections.Generic;

namespace Meadow.Hardware
{
    public class CellOperator
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Operator { get; set; }
        public string Code { get; set; }
    }
    public interface ICellNetworkAdapter : INetworkAdapter
    {
        public List<CellOperator> ScanNetwork ();       
    }
}
