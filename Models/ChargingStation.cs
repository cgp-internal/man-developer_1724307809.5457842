public enum ConnectorType
{
    Unknown,
    Type1,
    Type2,
    CCS,
    CHAdeMO,
    Tesla
}

public class Connector
{
    public int Id { get; set; }
    public int ChargingStationId { get; set; }
    public ConnectorType Type { get; set; }
    public int Power { get; set; }
}

public class ChargingStation
{
    public int Id { get; set; }
    public string Identifier { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public bool IsAvailable { get; set; }
    public int MaxPower { get; set; }
    public int ConnectorCount { get; set; }
    public virtual ICollection<Connector> Connectors { get; set; }
}