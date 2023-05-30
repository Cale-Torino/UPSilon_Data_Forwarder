using static UPSilon_Data_Forwarder.Classes.Json.DeserializeClass;

namespace UPSilon_Data_Forwarder.Classes.Json
{
    internal class SerializeClass
    {
        public DatapointsResponse Serialized(float InVoltage,float FaultVoltage,float OutputVoltage,int Current,float Frequency,float BatteryVoltage,string Temperature,string UPSBinary)
        {
            DatapointsResponse datapoints = new DatapointsResponse
            {
                Message = "success",
                Datapoints = new List<Datapoint>()
                {
                    new Datapoint
                    {
                        Date = DateTime.Now,
                        InVoltage = InVoltage,
                        FaultVoltage = FaultVoltage,
                        OutputVoltage = OutputVoltage,
                        Current = Current,
                        Frequency = Frequency,
                        BatteryVoltage = BatteryVoltage,
                        Temperature = Temperature,
                        UPSBinary = UPSBinary
                    }
                }
            };
            return datapoints;
        }
    }
}
