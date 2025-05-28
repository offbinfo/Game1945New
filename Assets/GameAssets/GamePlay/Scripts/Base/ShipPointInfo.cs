using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ShipPointInfo
{
    public string Name;
    public float Rot;
}

[Serializable]
public class ShipPointLevelInfo
{
    public List<ShipPointInfo> Levels;
}
