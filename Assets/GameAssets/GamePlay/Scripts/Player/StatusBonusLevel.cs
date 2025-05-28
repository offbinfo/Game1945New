using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
public class StatusBonusLevel
{
    public Stat stat;
    public int level;

    public StatusBonusLevel(Stat stat, int level)
    {
        this.stat = stat;
        this.level = level;
    }
}
